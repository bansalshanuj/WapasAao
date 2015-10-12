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
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
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

public class UpdateCompanyDetailForm extends Activity {

  @Override
  protected void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.update_company_detail_form);

    SharedPreferences sharedPref = getSharedPreferences("FileName", Context.MODE_PRIVATE);
    final String vendorId = sharedPref.getString("vendorId", "DEFAULT");
    final String salespersonId = sharedPref.getString("salespersonId", "DEFAULT");
    Intent intent = getIntent();

    final String vendorName = intent.getStringExtra("vendorName");
    final String vendorAddress = intent.getStringExtra("address");
    final String conversionFactor = intent.getStringExtra("conversionFactor");

    EditText vendorNameText = ((EditText) findViewById(R.id.business_name));
    final EditText vendorAddressText = ((EditText) findViewById(R.id.business_address));
    final EditText conversionFactorText = ((EditText) findViewById(R.id.payback_percent));
    conversionFactorText.setInputType(InputType.TYPE_CLASS_PHONE);

    vendorNameText.setText(vendorName);
    vendorNameText.setEnabled(false);
    vendorNameText.setTextColor(Color.GRAY);
    vendorAddressText.setText(vendorAddress);
    conversionFactorText.setText(conversionFactor);

    TextView btnCodeDetails = (TextView) findViewById(R.id.update_details_button);
    btnCodeDetails.setOnClickListener(new View.OnClickListener() {

      public void onClick(View v) {
        boolean requirement = true;
        String newVendorAddress = vendorAddressText.getText().toString();
        String newConversionFactor = conversionFactorText.getText().toString();

        requirement &= Validation.checkBusinessAddressValidity(vendorAddressText);
        requirement &= Validation.checkPercentageValidity(conversionFactorText);

        if (requirement) {
          v.setVisibility(View.GONE);
          ProgressBar progressBar = (ProgressBar) findViewById(R.id.cooldown_bar);
          progressBar.setVisibility(View.VISIBLE);
          new HttpUpdateVendorDetails().execute(getApplicationContext(), vendorId, salespersonId, newVendorAddress,
              newConversionFactor);
        }
      }
    });
  }

  private class HttpUpdateVendorDetails extends AsyncTask<Object, Void, String> {

    @Override
    protected String doInBackground(Object... params) {
      Context context = (Context) params[0];
      String vendorId = (String) params[1];
      String salespersonId = (String) params[2];
      String address = (String) params[3];
      String conversionFactor = (String) params[4];

      String url = CommonVariables.URL + "/updateVendor.php";
      String result = "";
      try {
        HttpClient httpClient = new DefaultHttpClient();
        HttpPost httpRequest = new HttpPost(url);

        List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>(2);
        nameValuePairs.add(new BasicNameValuePair("address", address));
        nameValuePairs.add(new BasicNameValuePair("conversionFactor", conversionFactor));
        nameValuePairs.add(new BasicNameValuePair("vendorId", vendorId));
        nameValuePairs.add(new BasicNameValuePair("salespersonId", salespersonId));

        httpRequest.setEntity(new UrlEncodedFormEntity(nameValuePairs));
        HttpResponse response = httpClient.execute(httpRequest);
        InputStreamReader inStream = new InputStreamReader(response.getEntity().getContent());
        BufferedReader buffReader = new BufferedReader(inStream);
        result = buffReader.readLine();
        JSONObject jsonObj = new JSONObject(result.toString());

        String error = jsonObj.getString("error");
        if (StringUtils.isBlank(error)) {
          SharedPreferences sharedPref = getSharedPreferences("FileName", Context.MODE_PRIVATE);
          SharedPreferences.Editor prefEditor = sharedPref.edit();
          prefEditor.putString("address", address);
          prefEditor.commit();
        }
        buffReader.close();
        inStream.close();
        return "Success";
      } catch (Exception e) {
        Log.d("", e.getMessage());
      }
      return "Failure";
    }

    @Override
    protected void onPostExecute(String s) {
      int duration = Toast.LENGTH_LONG;
      Toast toast = null;
      String message;

      if (s.trim().equalsIgnoreCase("SUCCESS")) {
        message = "successfully updated";
      } else {
        message = "failed to connect";
      }
      toast = Toast.makeText(getApplicationContext(), message, duration);
      toast.setGravity(Gravity.TOP | Gravity.LEFT, 0, 100);
      toast.show();

      ProgressBar progressBar = (ProgressBar) findViewById(R.id.cooldown_bar);
      progressBar.setVisibility(View.GONE);

      TextView btnSendPoints = (TextView) findViewById(R.id.update_details_button);
      btnSendPoints.setVisibility(View.VISIBLE);

      Intent intent = new Intent(getApplicationContext(), TransactionForm.class);
      intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
      startActivity(intent);
      finish();
    }
  }
}
