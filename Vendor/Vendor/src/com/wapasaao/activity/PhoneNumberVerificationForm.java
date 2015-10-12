package com.wapasaao.activity;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

import org.apache.commons.lang3.StringUtils;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpConnectionParams;
import org.apache.http.params.HttpParams;
import org.json.JSONObject;

import android.app.Activity;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.telephony.SmsManager;
import android.telephony.SmsMessage;
import android.text.InputType;
import android.util.Log;
import android.view.Gravity;
import android.view.View;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.wapasaao.validator.Validation;
import com.wapasaao.vendor.R;

public class PhoneNumberVerificationForm extends Activity {

  private final BroadcastReceiver incomingSMS = new IncomingSms();

  @Override
  protected void onCreate(Bundle savedInstanceState) {

    super.onCreate(savedInstanceState);
    setContentView(R.layout.phone_number_verification_form);

    IntentFilter filter = new IntentFilter();
    filter.addAction("android.provider.Telephony.SMS_RECEIVED");
    registerReceiver(incomingSMS, filter);

    EditText phoneNumberText = (EditText) findViewById(R.id.phone_number_info);
    phoneNumberText.setInputType(InputType.TYPE_CLASS_PHONE);

    SharedPreferences sharedPref = getSharedPreferences("FileName", Context.MODE_PRIVATE);
    Boolean verified = sharedPref.getBoolean("verified", false);
    if (verified == true) {
      Intent intent = new Intent(this, CompanyDetailForm.class);
      intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
      startActivity(intent);
      finish();
    }

    TextView btnSendSMS = (TextView) findViewById(R.id.verify_button);
    btnSendSMS.setOnClickListener(new View.OnClickListener() {

      public void onClick(View v) {
        EditText phoneNumberText = (EditText) findViewById(R.id.phone_number_info);
        EditText nameText = (EditText) findViewById(R.id.name_info);
        boolean requirement = true;

        requirement &= Validation.checkNameValidity(nameText);
        requirement &= Validation.checkPhoneNumberValidity(phoneNumberText);

        if (requirement) {
          String name = nameText.getText().toString();
          String phoneNumber = phoneNumberText.getText().toString();

          v.setVisibility(View.GONE);
          ProgressBar progressBar = (ProgressBar) findViewById(R.id.progress_bar_register_self);
          progressBar.setVisibility(View.VISIBLE);

          Toast toast = Toast.makeText(getApplicationContext(), "verifying...", Toast.LENGTH_LONG);
          toast.setGravity(Gravity.TOP | Gravity.LEFT, 0, 80);
          toast.show();

          int min = 111111;
          int max = 999999;
          Random rand = new Random();
          int randomNum = rand.nextInt((max - min) + 1) + min;
          String verificationCode = String.valueOf(randomNum);
          sendSMS(phoneNumber, verificationCode);

          SharedPreferences sharedPref = getSharedPreferences("FileName", MODE_PRIVATE);
          SharedPreferences.Editor prefEditor = sharedPref.edit();
          prefEditor.putString("salespersonName", name);
          prefEditor.putString("phoneNumber", phoneNumber);
          prefEditor.putString("verificationCode", verificationCode);
          prefEditor.commit();
        }
      }
    });
  }

  @Override
  public void onDestroy() {
    super.onPause();
    unregisterReceiver(incomingSMS);
  }

  private void sendSMS(String phoneNumber, String message) {
    SmsManager sms = SmsManager.getDefault();
    sms.sendTextMessage(phoneNumber, null, message, null, null);
  }

  private class IncomingSms extends BroadcastReceiver {

    public void onReceive(Context context, Intent intent) {

      final Bundle bundle = intent.getExtras();
      try {
        SharedPreferences sharedPref = context.getSharedPreferences("FileName", Context.MODE_PRIVATE);
        String origPhoneNumber = sharedPref.getString("phoneNumber", "DEFAULT");
        String origVerificationCode = sharedPref.getString("verificationCode", "DEFAULT");

        if (bundle != null) {
          final Object[] pdusObj = (Object[]) bundle.get("pdus");
          for (int i = 0; i < pdusObj.length; i++) {
            SmsMessage currentMessage = SmsMessage.createFromPdu((byte[]) pdusObj[i]);
            String senderNum = currentMessage.getDisplayOriginatingAddress().substring(3);
            String message = currentMessage.getDisplayMessageBody();

            int duration = Toast.LENGTH_LONG;
            Toast toast = null;
            if (message.equals(origVerificationCode) && senderNum.equals(origPhoneNumber)) {
              this.abortBroadcast();
              toast = Toast.makeText(context, "verified", duration);

              SharedPreferences.Editor prefEditor = sharedPref.edit();
              prefEditor.putBoolean("verified", true);
              prefEditor.commit();
              toast = Toast.makeText(context, "connecting to server", duration);
              toast.show();
              new HttpCheckSalesPerson().execute(context, senderNum, toast);
            } else {
              SharedPreferences.Editor prefEditor = sharedPref.edit();
              prefEditor.putString("phoneNumber", "DEFAULT");
              prefEditor.commit();
            }
            toast.show();

          }
        }
      } catch (Exception e) {
        Log.d("", e.getMessage());
      }
    }

    private class HttpCheckSalesPerson extends AsyncTask<Object, Void, String> {

      @Override
      protected String doInBackground(Object... params) {
        Context context = (Context) params[0];
        String salesPersonPhoneNumber = (String) params[1];
        Toast toast = (Toast) params[2];

        String url = CommonVariables.URL + "/checkSalesPerson.php";
        String result = "";
        try {
          HttpParams httpParameters = new BasicHttpParams();
          HttpConnectionParams.setConnectionTimeout(httpParameters, 5000);
          HttpConnectionParams.setSoTimeout(httpParameters, 10000);
          HttpClient httpClient = new DefaultHttpClient(httpParameters);
          HttpPost httpRequest = new HttpPost(url);
          httpRequest.setParams(httpParameters);
          List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
          nameValuePairs.add(new BasicNameValuePair("phoneNumber", salesPersonPhoneNumber));
          httpRequest.setEntity(new UrlEncodedFormEntity(nameValuePairs));
          HttpResponse response = httpClient.execute(httpRequest);
          InputStreamReader inStream = new InputStreamReader(response.getEntity().getContent());
          BufferedReader buffReader = new BufferedReader(inStream);
          result = buffReader.readLine();

          JSONObject jsonObj = new JSONObject(result.toString());
          String vendorCode = jsonObj.getString("vendorCode");
          String salespersonId = jsonObj.getString("salespersonId");
          String vendorId = jsonObj.getString("vendorId");
          String role = jsonObj.getString("role");
          String error = jsonObj.getString("error");

          if (StringUtils.isBlank(error)) {
            SharedPreferences sharedPref = context.getSharedPreferences("FileName", Context.MODE_PRIVATE);
            SharedPreferences.Editor prefEditor = sharedPref.edit();
            prefEditor.putString("vendorCode", vendorCode);
            prefEditor.putString("salespersonId", salespersonId);
            prefEditor.putString("vendorId", vendorId);
            prefEditor.putString("role", role);
            prefEditor.commit();
            toast.cancel();
            Intent intent = new Intent(context, TransactionForm.class);
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            context.startActivity(intent);
            finish();
          } else if (error.trim().equals("SALES_PERSON_DOES_NOT_EXISTS")) {
            toast.cancel();
            Intent intent = new Intent(context, CompanyDetailForm.class);
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            context.startActivity(intent);
            finish();
          }
          buffReader.close();
          inStream.close();

        } catch (Exception e) {
          Log.d("", e.getMessage());
        }
        return result;
      }

      @Override
      protected void onPostExecute(String s) {

      }
    }
  }

}
