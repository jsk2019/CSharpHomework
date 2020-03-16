using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    public class Order
    {
        public string ID;
        public string customer;
        public OrderDetail orderDetail;
        public Order(string ID, string customer,OrderDetail orderDetail)
        {
            this.ID = ID;
            this.customer = customer;
            this.orderDetail = orderDetail;
        }
        public override string ToString()
        {
            return "订单详细信息：" + "\nID:" + ID + "\n客户：" + customer + "\n价格：" + orderDetail.totalPrice+"\n详细信息：\n"+orderDetail.ToString();
        }
        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return obj != null && order.ID == ID && order.customer == customer;
        }
    }
    public class InfoList
    {
        public static List<Order> list = new List<Order>();
    }
}
