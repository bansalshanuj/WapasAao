package com.wapasaao.activity;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.text.DecimalFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.TimeZone;

import org.apache.commons.lang3.StringUtils;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.wapasaao.model.Customer;
import com.wapasaao.model.Salesperson;
import com.wapasaao.model.Transaction;
import com.wapasaao.model.Vendor;
import com.wapasaao.vendor.R;

public class TransactionDetails extends Activity {

  @Override
  protected void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.transaction_details);

    final Intent intent = getIntent();
    String jsonResponse = intent.getStringExtra("customerDetailResponse");
    final String amount = intent.getStringExtra("amount");
    long amountDec = Long.parseLong(amount);
    final boolean isDebit = intent.getBooleanExtra("isDebit", true);
    try {
      final JSONObject jsonObj = new JSONObject(jsonResponse);
      String username = jsonObj.getString("username");
      SharedPreferences sharedPref = getSharedPreferences("FileName", Context.MODE_PRIVATE);
      final String salespersonId = sharedPref.getString("salespersonId", "DEFAULT");
      final String vendorId = sharedPref.getString("vendorId", "DEFAULT");
      String c = jsonObj.getString("conversionFactor");
      long conversionFactor = Long.parseLong(c);

      int transactionCount = jsonObj.getInt("transactionCount");
      long points = jsonObj.getLong("points");

      if (StringUtils.isNotBlank(username) && !username.equalsIgnoreCase("null")) {
        TextView usernameText = ((TextView) findViewById(R.id.username));
        usernameText.setText(username);
      }

      TextView transactionText = ((TextView) findViewById(R.id.billing_amount));
      transactionText.setText(amount);

      TextView discountText = ((TextView) findViewById(R.id.discount));
      long discount = 0L;
      if (isDebit) {
        if (amountDec < points) {
          discount = amountDec;
        } else {
          discount = points;
        }
      }

      DecimalFormat dc = new DecimalFormat("0.00");
      String discountPercentage = dc.format((discount * 100.00) / amountDec);

      discountText.setText(Long.toString(discount) + "(" + discountPercentage + "%)");
      final String debitAmount = Long.toString(discount);

      TextView finalBilltext = ((TextView) findViewById(R.id.final_bill));
      finalBilltext.setText(Long.toString((amountDec - discount)));

      TextView redeemPointText = ((TextView) findViewById(R.id.redeem_points));
      final long creditAmount = amountDec * conversionFactor / 100;
      redeemPointText.setText(Long.toString(creditAmount));
      TextView totalTransactionText = ((TextView) findViewById(R.id.total_transactions));
      totalTransactionText.setText(jsonObj.getString("transactionCount"));

      if (Long.parseLong(jsonObj.getString("transactionCount")) == 0L) {
        TextView transactionsLabel = ((TextView) findViewById(R.id.label_transactions));
        transactionsLabel.setVisibility(View.GONE);
      }

      Customer customer = new Customer(jsonObj.getString("userId"), null, jsonObj.getString("points"));
      Vendor vendor = new Vendor(jsonObj.getString("vendorId"), null, null, null);
      if (!jsonObj.getString("error").trim().equals("USER_DOES_NOT_EXIST")) {
        JSONArray transactionJSON = jsonObj.getJSONArray("customerDetails");
        List<Transaction> transactions = new ArrayList<Transaction>();

        for (int i = 0; i < transactionCount; i++) {
          JSONObject tr = transactionJSON.getJSONObject(i);
          Salesperson salesperson = new Salesperson(tr.getString("salespersonId"), null, null, null, vendor);
          Transaction transaction = new Transaction(null, customer, salesperson, tr.getString("amount"),
              tr.getString("points"), tr.getString("type"), tr.getString("transactionTime"));
          transactions.add(transaction);
        }
        ListViewAdapter adapter = new ListViewAdapter(this, transactions);
        ListView listView = (ListView) findViewById(R.id.listview);
        listView.setAdapter(adapter);
      }

      TextView btnCodeDetails = (TextView) findViewById(R.id.send_credit_button);
      btnCodeDetails.setOnClickListener(new View.OnClickListener() {

        public void onClick(View v) {
          v.setVisibility(View.GONE);
          ProgressBar progressBar = (ProgressBar) findViewById(R.id.cooldown_bar);
          progressBar.setVisibility(View.VISIBLE);
          new HttpTransaction().execute(getApplicationContext(), salespersonId, vendorId,
              intent.getStringExtra("userPhoneNumber"), Long.toString(creditAmount), debitAmount, amount, isDebit);
        }
      });
    } catch (JSONException e) {
      // TODO Auto-generated catch block
      Log.d("", e.getMessage());
    }

  }

  @Override
  public void onBackPressed() {
    Intent intent = new Intent(getApplicationContext(), TransactionForm.class);
    startActivity(intent);
    finish();
  }

  private class ListViewAdapter extends ArrayAdapter<Transaction> {

    private final Context context;

    private final List<Transaction> details;

    public ListViewAdapter(Context context, List<Transaction> details) {
      super(context, R.layout.transaction_listview, details);
      this.context = context;
      this.details = details;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
      LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
      Transaction detail = details.get(position);
      View rowView = inflater.inflate(R.layout.transaction_listview, parent, false);

      TextView dateText = (TextView) rowView.findViewById(R.id.label_date);
      Date date = null;
      try {
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        sdf.setTimeZone(TimeZone.getTimeZone("UTC"));
        date = sdf.parse(detail.getCreatedTime());

        sdf.setTimeZone(TimeZone.getTimeZone("Asia/Kolkata"));
        sdf.applyPattern("EEE, dd-MMM-yy 'at' hh:mm a");
        dateText.setText(sdf.format(date));
      } catch (ParseException e1) {
        e1.printStackTrace();
      }

      TextView latest_transactionText = (TextView) rowView.findViewById(R.id.latest_transaction);
      latest_transactionText.setText("Offered Rs." + detail.getPoints());

      TextView accountPointsText = (TextView) rowView.findViewById(R.id.accountPoints);
      accountPointsText.setText("Rs." + detail.getAmount());

      return rowView;
    }
  }

  private class HttpTransaction extends AsyncTask<Object, Void, String> {

    @Override
    protected String doInBackground(Object... params) {
      Context context = (Context) params[0];
      String salespersonId = (String) params[1];
      String vendorId = (String) params[2];
      String userPhoneNumber = (String) params[3];
      String creditAmount = (String) params[4];
      String debitAmount = (String) params[5];
      String billingAmount = (String) params[6];
      boolean isDebit = (Boolean) params[7];

      String url = CommonVariables.URL + "/transaction.php";
      String result = "";
      try {
        HttpClient httpClient = new DefaultHttpClient();
        HttpPost httpRequest = new HttpPost(url);

        List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
        nameValuePairs.add(new BasicNameValuePair("salespersonId", salespersonId));
        nameValuePairs.add(new BasicNameValuePair("vendorId", vendorId));
        nameValuePairs.add(new BasicNameValuePair("userPhoneNumber", userPhoneNumber));
        nameValuePairs.add(new BasicNameValuePair("creditAmount", creditAmount));
        nameValuePairs.add(new BasicNameValuePair("billingAmount", billingAmount));
        nameValuePairs.add(new BasicNameValuePair("isDebit", isDebit ? "true" : "false"));
        nameValuePairs.add(new BasicNameValuePair("debitAmount", debitAmount));

        httpRequest.setEntity(new UrlEncodedFormEntity(nameValuePairs));
        HttpResponse response = httpClient.execute(httpRequest);
        InputStreamReader inStream = new InputStreamReader(response.getEntity().getContent());
        BufferedReader buffReader = new BufferedReader(inStream);
        result = buffReader.readLine();

        buffReader.close();
        inStream.close();
      } catch (Exception e) {
        Log.d("", e.getMessage());
        return "fail";
      }
      return result;
    }

    @Override
    protected void onPostExecute(String s) {
      int duration = Toast.LENGTH_LONG;
      Toast toast = null;
      if (s.trim().equals("success")) {
        toast = Toast.makeText(getApplicationContext(), "successfully sent", duration);
        Intent intent = new Intent(getApplicationContext(), TransactionForm.class);
        startActivity(intent);
        finish();
      } else {
        toast = Toast.makeText(getApplicationContext(), "failed to connect", duration);
        TextView btnCodeDetails = (TextView) findViewById(R.id.send_credit_button);
        btnCodeDetails.setVisibility(View.VISIBLE);
        ProgressBar progressBar = (ProgressBar) findViewById(R.id.cooldown_bar);
        progressBar.setVisibility(View.GONE);
      }
      toast.setGravity(Gravity.TOP | Gravity.LEFT, 0, 100);
      toast.show();
    }
  }
}
