package com.wapasaao.validator;

import java.util.regex.Pattern;

import org.apache.commons.lang3.StringUtils;

import android.widget.EditText;

public class Validation {

  private static final String NAME_REGEX = "";

  private static final String PHONE__NUMBER_REGEX = "";

  private static final String AMOUNT_REGEX = "";

  private static final String CODE_REGEX = "";

  private static final String PERCENTAGE_REGEX = "";

  public static boolean checkNameValidity(EditText editText) {
    return isValid(editText, NAME_REGEX, "Please provide your name.Minimum length should be 5 characters");
  }

  public static boolean checkPhoneNumberValidity(EditText editText) {
    return isValid(editText, PHONE__NUMBER_REGEX, "Please provide your mobile number.Enter 10 digit mobile number");
  }

  public static boolean checkAmountValidity(EditText editText) {
    return isValid(editText, AMOUNT_REGEX, "Please provide the amount.Maximum amount can be 99999");
  }

  public static boolean checkCodeValidity(EditText editText) {
    return isValid(editText, CODE_REGEX, "Please provide the code.Please provide the 6 code");
  }

  public static boolean checkPercentageValidity(EditText editText) {
    return isValid(editText, PERCENTAGE_REGEX, "Please provide the percentage.Enter the percentage between 0 to 100");
  }

  public static boolean checkBusinessNameValidity(EditText editText) {
    return isValid(editText, "", "Please provide the business name.");
  }

  public static boolean checkBusinessAddressValidity(EditText editText) {
    return isValid(editText, "", "Please provide the business address.");
  }

  public static boolean checkCodeLimitValidity(EditText editText) {
    return isValid(editText, AMOUNT_REGEX, "Please provide the amount.Maximum amount can be 99999");
  }

  private static boolean isValid(EditText editText, String regex, String errMsg) {

    String text = editText.getText().toString().trim();
    editText.setError(null);
    String[] errText = errMsg.split("\\.");

    if (StringUtils.isBlank(text)) {
      editText.setError(errText[0]);
      return false;
    }

    if ((StringUtils.isNotBlank(regex)) && (!Pattern.matches(regex, text))) {
      editText.setError(errText[1]);
      return false;
    }

    return true;
  }
}
