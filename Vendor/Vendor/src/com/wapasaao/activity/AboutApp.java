package com.wapasaao.activity;

import android.app.Activity;
import android.content.Context;
import android.content.pm.PackageManager.NameNotFoundException;
import android.os.Bundle;
import android.util.Log;
import android.view.Window;
import android.view.WindowManager;
import android.widget.TextView;

import com.wapasaao.vendor.R;

public class AboutApp extends Activity {

  @Override
  protected void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);

    requestWindowFeature(Window.FEATURE_NO_TITLE);
    getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
    setContentView(R.layout.about_app);

    try {
      Context context = getApplicationContext();
      String versionName = context.getPackageManager().getPackageInfo(context.getPackageName(), 0).versionName;
      TextView versionText = ((TextView) findViewById(R.id.app_version));
      versionText.setText("Version " + versionName);
    } catch (NameNotFoundException e) {
      Log.d("", e.getMessage());
    }

  }
}
