package com.wapasaao.model;

public class Vendor {

  private String id;

  private String code;

  private String conversionFactor;

  private String name;

  public Vendor() {

  }

  public Vendor(String id, String code, String conversionFactor, String name) {
    this.id = id;
    this.code = code;
    this.conversionFactor = conversionFactor;
    this.name = name;
  }

  public String getId() {
    return id;
  }

  public void setId(String id) {
    this.id = id;
  }

  public String getCode() {
    return code;
  }

  public void setCode(String code) {
    this.code = code;
  }

  public String getConversionFactor() {
    return conversionFactor;
  }

  public void setConversionFactor(String conversionFactor) {
    this.conversionFactor = conversionFactor;
  }

  public String getName() {
    return name;
  }

  public void setName(String name) {
    this.name = name;
  }

}
