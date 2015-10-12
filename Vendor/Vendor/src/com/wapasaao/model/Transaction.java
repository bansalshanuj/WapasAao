package com.wapasaao.model;

public class Transaction {

  private String id;

  private Customer customer;

  private Salesperson salesperson;

  private String amount;

  private String points;

  private String type;

  private String createdTime;

  public Transaction() {

  }

  public Transaction(String id, Customer customer, Salesperson salesperson, String amount, String points, String type,
      String createdTime) {
    this.id = id;
    this.customer = customer;
    this.salesperson = salesperson;
    this.amount = amount;
    this.points = points;
    this.type = type;
    this.createdTime = createdTime;
  }

  public String getId() {
    return id;
  }

  public void setId(String id) {
    this.id = id;
  }

  public Customer getCustomer() {
    return customer;
  }

  public void setCustomer(Customer customer) {
    this.customer = customer;
  }

  public String getAmount() {
    return amount;
  }

  public void setAmount(String amount) {
    this.amount = amount;
  }

  public String getPoints() {
    return points;
  }

  public void setPoints(String points) {
    this.points = points;
  }

  public String getType() {
    return type;
  }

  public void setType(String type) {
    this.type = type;
  }

  public String getCreatedTime() {
    return createdTime;
  }

  public void setCreatedTime(String createdTime) {
    this.createdTime = createdTime;
  }

  public Salesperson getSalesperson() {
    return salesperson;
  }

  public void setSalesperson(Salesperson salesperson) {
    this.salesperson = salesperson;
  }

}
