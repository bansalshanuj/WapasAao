package com.wapasaao.model;

public class Customer {

  private String id;

  private String phoneNumber;

  private String points;

  public Customer() {

  }

  public Customer(String id, String phoneNumber, String points) {
    this.id = id;
    this.phoneNumber = phoneNumber;
    this.points = points;
  }

  public String getId() {
    return id;
  }

  public void setId(String id) {
    this.id = id;
  }

  public String getPhoneNumber() {
    return phoneNumber;
  }

  public void setPhoneNumber(String phoneNumber) {
    this.phoneNumber = phoneNumber;
  }

  public String getPoints() {
    return points;
  }

  public void setPoints(String points) {
    this.points = points;
  }

}
