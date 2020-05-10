﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace OrderForm
{

  /**
   **/
  public class Order:IComparable<Order>{
    [Key]
    public int OrderID { get; set; }

    private List<OrderItem> items;

    public Customer Customer { get; set; }

    public string CustomerName { get=> (Customer!=null)? Customer.Name:""; }

    public DateTime CreateTime { get; set; }


    public Order() {items = new List<OrderItem>(); CreateTime = DateTime.Now; }

    public Order(int OrderID, Customer customer, List<OrderItem> items) {
      this.OrderID = OrderID;
      this.Customer = customer;
      this.CreateTime = DateTime.Now;
      this.items = (items == null) ? new List<OrderItem>() : items;
    }

    public List<OrderItem> Items {
      get { return items; }
    }

    public double TotalPrice {
      get => items.Sum(item => item.TotalPrice);
    }

    public void AddItem(OrderItem orderItem) {
      if(Items.Contains(orderItem))
        throw new ApplicationException($"添加错误：订单项{orderItem.GoodsName} 已经存在!");
      Items.Add(orderItem);
    }

    public void RemoveItem(OrderItem orderItem) {
      Items.Remove(orderItem);
    }

    public override string ToString() {
      StringBuilder strBuilder = new StringBuilder();
      strBuilder.Append($"OrderID:{OrderID}, customer:{Customer},orderTime:{CreateTime},totalPrice：{TotalPrice}");
      items.ForEach(od => strBuilder.Append("\n\t" + od));
      return strBuilder.ToString() ;
    }

    public override bool Equals(object obj) {
      var order = obj as Order;
      return order != null &&
             OrderID == order.OrderID;
    }

    public override int GetHashCode() {
      var hashCode = -531220479;
      hashCode = hashCode * -1521134295 + OrderID.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerName);
      hashCode = hashCode * -1521134295 + CreateTime.GetHashCode();
      return hashCode;
    }

    public int CompareTo(Order other) {
      if (other == null) return 1;
      return this.OrderID.CompareTo(other.OrderID);
    }

    }
}
