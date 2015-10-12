package com.wapasaao.activity;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang3.StringUtils;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONObject;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.text.InputType;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.TextView;

import com.wapasaao.validator.Validation;
import com.wapasaao.vendor.R;

public class CompanyDetailForm extends Activity {

  @Override
  protected void onCreate(Bundle savedInstanceState) {

    super.onCreate(savedInstanceState);
    setContentView(R.layout.customer_detail_form);

    final Context context = getApplicationContext();
    SharedPreferences sharedPref = context.getSharedPreferences("FileName", Context.MODE_PRIVATE);
    String salespersonId = sharedPref.getString("salespersonId", "DEFAULT");
    if (!salespersonId.equalsIgnoreCase("DEFAULT")) {
      Intent intent = new Intent(context, TransactionForm.class);
      intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
      context.startActivity(intent);
      finish();
    }

    EditText conversionFactorText = ((EditText) findViewById(R.id.payback_percent));
    conversionFactorText.setInputType(InputType.TYPE_CLASS_PHONE);

    TextView btnSubmitDetails = (TextView) findViewById(R.id.submit_details_button);
    btnSubmitDetails.setOnClickListener(new View.OnClickListener() {

      public void onClick(View v) {
        EditText vendorNameText = ((EditText) findViewById(R.id.business_name));
        EditText vendorAddressText = ((EditText) findViewById(R.id.business_address));
        EditText conversionFactorText = ((EditText) findViewById(R.id.payback_percent));

        boolean requirement = true;
        requirement &= Validation.checkBusinessNameValidity(vendorNameText);
        requirement &= Validation.checkBusinessAddressValidity(vendorAddressText);
        requirement &= Validation.checkPercentageValidity(conversionFactorText);

        if (requirement) {
          String vendorName = vendorNameText.getText().toString();
          String vendorAddress = vendorAddressText.getText().toString();
          String conversionFactor = conversionFactorText.getText().toString();

          v.setVisibility(View.GONE);
          ProgressBar progressBar = (ProgressBar) findViewById(R.id.cooldown_bar);
          progressBar.setVisibility(View.VISIBLE);

          new HttpRegisterSubmit().execute(context, vendorName, vendorAddress, conversionFactor);
        }
      }
    });
  }

  private class HttpRegisterSubmit extends AsyncTask<Object, Void, String> {

    @Override
    protected String doInBackground(Object... params) {
      Context context = (Context) params[0];
      String vendorName = (String) params[1];
      String vendorAddress = (String) params[2];
      String conversionFactor = (String) params[3];

      SharedPreferences sharedPref = context.getSharedPreferences("FileName", Context.MODE_PRIVATE);
      String phoneNumber = sharedPref.getString("phoneNumber", "DEFAULT");
      String salespersonName = sharedPref.getString("salespersonName", "DEFAULT");

      String url = CommonVariables.URL + "/addvendor.php";
      String result = "";
      try {
        HttpClient httpClient = new DefaultHttpClient();
        HttpPost httpRequest = new HttpPost(url);

        List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>(2);
        nameValuePairs.add(new BasicNameValuePair("vendorName", vendorName));
        nameValuePairs.add(new BasicNameValuePair("address", vendorAddress));
        nameValuePairs.add(new BasicNameValuePair("salespersonName", salespersonName));
        nameValuePairs.add(new BasicNameValuePair("code", "-1"));
        nameValuePairs.add(new BasicNameValuePair("conversionFactor", conversionFactor));
        nameValuePairs.add(new BasicNameValuePair("phoneNumber", phoneNumber));

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
          SharedPreferences.Editor prefEditor = sharedPref.edit();
          prefEditor.putString("vendorCode", vendorCode);
          prefEditor.putString("salespersonId", salespersonId);
          prefEditor.putString("vendorId", vendorId);
          prefEditor.putString("role", role);
          prefEditor.putString("vendorName", vendorName);
          prefEditor.putString("vendorAddress", vendorAddress);
          prefEditor.commit();

          Intent intent = new Intent(context, TransactionForm.class);
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
