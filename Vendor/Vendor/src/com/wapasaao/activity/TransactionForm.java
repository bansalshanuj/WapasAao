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
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpConnectionParams;
import org.apache.http.params.HttpParams;
import org.json.JSONObject;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.text.InputType;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.TextView;

import com.wapasaao.validator.Validation;
import com.wapasaao.vendor.R;

public class TransactionForm extends Activity {

  @Override
  protected void onCreate(Bundle savedInstanceState) {

    super.onCreate(savedInstanceState);
    setContentView(R.layout.transaction_form);

    EditText amountText = (EditText) findViewById(R.id.send_amount);
    amountText.setInputType(InputType.TYPE_CLASS_PHONE);

    EditText phoneText = (EditText) findViewById(R.id.send_phone_number);
    phoneText.setInputType(InputType.TYPE_CLASS_PHONE);

    TextView btnGetCustomerDetails = (TextView) findViewById(R.id.get_customer_detail_button);
    btnGetCustomerDetails.setOnClickListener(new View.OnClickListener() {

      public void onClick(View v) {
        EditText amountText = (EditText) findViewById(R.id.send_amount);
        EditText phoneText = (EditText) findViewById(R.id.send_phone_number);
        CheckBox codeCheckBox = (CheckBox) findViewById(R.id.code_check_box);

        String amount = amountText.getText().toString();
        String phoneNumber = phoneText.getText().toString();
        boolean isDebit = codeCheckBox.isChecked();

        if (Validation.checkAmountValidity(amountText) && Validation.checkPhoneNumberValidity(phoneText)) {
          v.setVisibility(View.GONE);
          ProgressBar progressBar = (ProgressBar) findViewById(R.id.cooldown_bar);
          progressBar.setVisibility(View.VISIBLE);
          new HttpGetCustomerDetails().execute(getApplicationContext(), phoneNumber, amount, isDebit);
        }
      }
    });
  }

  @Override
  public boolean onOptionsItemSelected(MenuItem item) {
    switch (item.getItemId()) {
      case R.id.action_settings:
        SharedPreferences sharedPref = getSharedPreferences("FileName", Context.MODE_PRIVATE);
        final String vendorId = sharedPref.getString("vendorId", "DEFAULT");
        new HttpGetVendorDetails().execute(getApplicationContext(), vendorId);
        return true;
      case R.id.action_about:
        Intent intent = new Intent(getApplicationContext(), AboutApp.class);
        startActivity(intent);
        return true;
      case R.id.action_feedback:
        intent = new Intent(getApplicationContext(), Feedback.class);
        startActivity(intent);
        return true;
      default:
        return super.onOptionsItemSelected(item);
    }
  }

  @Override
  public boolean onCreateOptionsMenu(Menu menu) {
    SharedPreferences sharedPref = getApplicationContext().getSharedPreferences("FileName", Context.MODE_PRIVATE);
    String role = sharedPref.getString("role", "SALES_PERSON");
    if (role.equalsIgnoreCase("SUPER_ADMIN")) {
      getMenuInflater().inflate(R.menu.menu_settings, menu);
    }

    getMenuInflater().inflate(R.menu.menu_feedback, menu);
    getMenuInflater().inflate(R.menu.menu_about, menu);
    return true;
  }

  private class HttpGetVendorDetails extends AsyncTask<Object, Void, String> {

    @Override
    protected String doInBackground(Object... params) {
      Context context = (Context) params[0];
      String vendorId = (String) params[1];
      String url = CommonVariables.URL + "/getVendorDetails.php";
      String result = "";
      try {
        HttpClient httpClient = new DefaultHttpClient();
        HttpPost httpRequest = new HttpPost(url);

        List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>(2);
        nameValuePairs.add(new BasicNameValuePair("vendorId", vendorId));

        httpRequest.setEntity(new UrlEncodedFormEntity(nameValuePairs));
        HttpResponse response = httpClient.execute(httpRequest);
        InputStreamReader inStream = new InputStreamReader(response.getEntity().getContent());
        BufferedReader buffReader = new BufferedReader(inStream);
        result = buffReader.readLine();
        JSONObject jsonObj = new JSONObject(result.toString());

        String error = jsonObj.getString("error");
        if (StringUtils.isBlank(error)) {
          Intent intent = new Intent(getApplicationContext(), UpdateCompanyDetailForm.class);
          intent.putExtra("vendorName", jsonObj.getString("businessName"));
          intent.putExtra("address", jsonObj.getString("businessAddress"));
          intent.putExtra("conversionFactor", jsonObj.getString("conversionFactor"));
          intent.putExtra("codeLimit", jsonObj.getString("codeLimit"));
          startActivity(intent);
        }
        buffReader.close();
        inStream.close();
      } catch (Exception e) {
        Log.d("", e.getMessage());
      }
      return "";
    }

    @Override
    protected void onPostExecute(String s) {

    }
  }

  private class HttpGetCustomerDetails extends AsyncTask<Object, Void, String> {

    @Override
    protected String doInBackground(Object... params) {
      Context context = (Context) params[0];
      String userPhoneNumber = (String) params[1];
      String transactionAmount = (String) params[2];
      boolean isDebit = (Boolean) params[3];

      String url = CommonVariables.URL + "/getCustomerDetails.php";
      String result = "";
      String error = "";
      try {
        HttpParams httpParameters = new BasicHttpParams();
        HttpConnectionParams.setConnectionTimeout(httpParameters, 5000);
        HttpConnectionParams.setSoTimeout(httpParameters, 10000);

        HttpClient httpClient = new DefaultHttpClient(httpParameters);
        HttpPost httpRequest = new HttpPost(url);
        httpRequest.setParams(httpParameters);

        SharedPreferences sharedPref = context.getSharedPreferences("FileName", Context.MODE_PRIVATE);
        String salespersonId = sharedPref.getString("salespersonId", "DEFAULT");
        String vendorId = sharedPref.getString("vendorId", "DEFAULT");

        List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>(3);
        nameValuePairs.add(new BasicNameValuePair("userPhoneNumber", userPhoneNumber));
        nameValuePairs.add(new BasicNameValuePair("salespersonId", salespersonId));
        nameValuePairs.add(new BasicNameValuePair("vendorId", vendorId));

        httpRequest.setEntity(new UrlEncodedFormEntity(nameValuePairs));
        HttpResponse response = httpClient.execute(httpRequest);
        InputStreamReader inStream = new InputStreamReader(response.getEntity().getContent());
        BufferedReader buffReader = new BufferedReader(inStream);
        result = buffReader.readLine();

        JSONObject jsonObj = new JSONObject(result);
        error = jsonObj.getString("error");
        if (StringUtils.isBlank(error) || (error.equalsIgnoreCase("USER_DOES_NOT_EXIST"))) {
          Intent intent = new Intent(context, TransactionDetails.class);
          intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
          intent.putExtra("customerDetailResponse", result);
          intent.putExtra("amount", transactionAmount);
          intent.putExtra("userPhoneNumber", userPhoneNumber);
          intent.putExtra("isDebit", isDebit);
          context.startActivity(intent);
          finish();
        }
        buffReader.close();
        inStream.close();
      } catch (Exception e) {
        Log.d("", e.getMessage());
      }
      return error;
    }

    @Override
    protected void onPostExecute(String result) {

    }
  }
}