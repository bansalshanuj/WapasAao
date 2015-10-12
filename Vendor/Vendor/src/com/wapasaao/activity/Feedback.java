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

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.Gravity;
import android.view.View;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.wapasaao.vendor.R;

public class Feedback extends Activity {

  @Override
  protected void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.feedback_form);

    TextView btnSubmitFeedback = (TextView) findViewById(R.id.submit_details_button);
    btnSubmitFeedback.setOnClickListener(new View.OnClickListener() {

      public void onClick(View v) {
        EditText messageText = (EditText) findViewById(R.id.feedback);
        String message = messageText.getText().toString();

        if (StringUtils.isBlank(message)) {
          messageText.setError("Please provide your query!");
        } else {
          v.setVisibility(View.GONE);
          ProgressBar progressBar = (ProgressBar) findViewById(R.id.cooldown_bar);
          progressBar.setVisibility(View.VISIBLE);

          new HttpSendFeedback().execute(getApplicationContext(), message);
        }
      }
    });
  }

  private class HttpSendFeedback extends AsyncTask<Object, Void, String> {

    @Override
    protected String doInBackground(Object... params) {
      Context context = (Context) params[0];
      String message = (String) params[1];

      String url = CommonVariables.URL + "/feedback.php";
      try {
        HttpClient httpClient = new DefaultHttpClient();
        HttpPost httpRequest = new HttpPost(url);

        SharedPreferences sharedPref = context.getSharedPreferences("FileName", Context.MODE_PRIVATE);
        String salespersonId = sharedPref.getString("salespersonId", "DEFAULT");

        List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
        nameValuePairs.add(new BasicNameValuePair("fromAddress", salespersonId));
        nameValuePairs.add(new BasicNameValuePair("type", "SALESPERSON"));
        nameValuePairs.add(new BasicNameValuePair("message", message));

        httpRequest.setEntity(new UrlEncodedFormEntity(nameValuePairs));
        HttpResponse response = httpClient.execute(httpRequest);
        InputStreamReader inStream = new InputStreamReader(response.getEntity().getContent());
        BufferedReader buffReader = new BufferedReader(inStream);
        String result = buffReader.readLine();

        buffReader.close();
        inStream.close();
      } catch (Exception e) {
        Log.d("", e.getMessage());
        return "failure";
      }
      return "success";
    }

    @Override
    protected void onPostExecute(String s) {
      int duration = Toast.LENGTH_LONG;
      Toast toast = null;
      if ("success".equalsIgnoreCase(s)) {
        toast = Toast.makeText(getApplicationContext(), "successfully sent", duration);
        Intent intent = new Intent(getApplicationContext(), TransactionForm.class);
        startActivity(intent);
        finish();
      } else {
        toast = Toast.makeText(getApplicationContext(), "failed to connect", duration);
        TextView btnSubmitFeedback = (TextView) findViewById(R.id.submit_details_button);
        btnSubmitFeedback.setVisibility(View.VISIBLE);
        ProgressBar progressBar = (ProgressBar) findViewById(R.id.cooldown_bar);
        progressBar.setVisibility(View.GONE);
      }
      toast.setGravity(Gravity.TOP | Gravity.LEFT, 0, 100);
      toast.show();
    }
  }
}
