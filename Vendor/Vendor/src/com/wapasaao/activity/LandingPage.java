package com.wapasaao.activity;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

import com.wapasaao.vendor.R;

public class LandingPage extends Activity {

  @Override
  protected void onCreate(Bundle savedInstanceState) {

    super.onCreate(savedInstanceState);
    setContentView(R.layout.landing_page);

    SharedPreferences sharedPref = getSharedPreferences("FileName", Context.MODE_PRIVATE);
    Boolean agreed = sharedPref.getBoolean("agreed", false);
    if (agreed == true) {
      Intent intent = new Intent(this, PhoneNumberVerificationForm.class);
      intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
      startActivity(intent);
      finish();
    }

    TextView linkTNC = (TextView) findViewById(R.id.textTNC);
    linkTNC.setOnClickListener(new View.OnClickListener() {

      public void onClick(View v) {
        Intent browserIntent = new Intent(Intent.ACTION_VIEW, Uri.parse("http://www.wapasaao.com/legal/vendor.html"));
        startActivity(browserIntent);
      }
    });

    TextView agree_button = (TextView) findViewById(R.id.TNC_agree_button);
    agree_button.setOnClickListener(new View.OnClickListener() {

      public void onClick(View v) {
        SharedPreferences sharedPref = getSharedPreferences("FileName", Context.MODE_PRIVATE);
        SharedPreferences.Editor prefEditor = sharedPref.edit();
        prefEditor.putBoolean("agreed", true);
        prefEditor.commit();
        Intent browserIntent = new Intent(getApplicationContext(), PhoneNumberVerificationForm.class);
        browserIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        startActivity(browserIntent);
        finish();
      }
    });
  }
}
