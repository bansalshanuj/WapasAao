package com.wapasaao.model;

public class Salesperson {

  private String id;

  private String name;

  private String phoneNumber;

  private String role;

  private Vendor vendor;

  public Salesperson() {

  }

  public Salesperson(String id, String name, String phoneNumber, String role, Vendor vendor) {
    this.id = id;
    this.name = name;
    this.phoneNumber = phoneNumber;
    this.role = role;
    this.vendor = vendor;
  }

  public String getId() {
    return id;
  }

  public void setId(String id) {
    this.id = id;
  }

  public String getName() {
    return name;
  }

  public void setName(String name) {
    this.name = name;
  }

  public String getPhoneNumber() {
    return phoneNumber;
  }

  public void setPhoneNumber(String phoneNumber) {
    this.phoneNumber = phoneNumber;
  }

  public String getRole() {
    return role;
  }

  public void setRole(String role) {
    this.role = role;
  }

  public Vendor getVendor() {
    return vendor;
  }

  public void setVendor(Vendor vendor) {
    this.vendor = vendor;
  }
}
