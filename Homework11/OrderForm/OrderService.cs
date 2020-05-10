using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderForm
{

    /**
     * The service class to manage orders
     * */
    public class OrderService
    {

        //the order list
        private List<Order> orders;


        public OrderService()
        {
            orders = new List<Order>();
        }

        public List<Order> Orders
        {
            get => orders;
        }

        public Order GetOrder(int id)
        {
            return orders.Where(o => o.OrderID == id).FirstOrDefault();
        }

        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
            {
                throw new ApplicationException($"添加错误: 订单{order.OrderID} 已经存在了!");
            }
            else
            {
                using (var context = new MysqlContext())
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                };
            }
            orders.Add(order);
        }

        public void RemoveOrder(int ID)
        {
            using (var context = new MysqlContext())
            {
                var order = context.Orders.FirstOrDefault(m => m.OrderID == ID);
                context.Orders.Remove(order);
            }
        }

        public List<Order> QueryOrdersByGoodsName(string goodsName)
        {
            using (var context = new MysqlContext())
            {
                var query = context.Orders.Where(order => order.Items.Exists(item => item.GoodsName == goodsName)).OrderBy(o => o.TotalPrice).ToList();
                return query;
            }
        }

        public List<Order> QueryOrdersByCustomerName(string customerName)
        {
            using (var context = new MysqlContext())
            {
                var query = context.Orders.Where(order => order.CustomerName == customerName)
                .OrderBy(o => o.TotalPrice)
                .ToList();
                return query;
            }
        }
        
        public void UpdateOrder(Order newOrder)
        {
            using (var context = new MysqlContext())
            {
                var query = context.Orders.Where(order => order.OrderID == newOrder.OrderID);
                if (query == null)
                {
                    throw new ApplicationException($"修改错误：订单 {newOrder.OrderID} 不存在!");
                }
                else
                {
                    RemoveOrder(newOrder.OrderID);
                    AddOrder(newOrder);
                }
            }
        }

        public void Sort()
        {
            using (var context = new MysqlContext())
            {
                var query = context.Orders.SqlQuery("SELECT * FROM orders").ToList();
                query.Sort();
            }
        }

        public void Sort(Func<Order, Order, int> func)
        {
            Orders.Sort((o1, o2) => func(o1, o2));
        }

        public void Export(String fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, Orders);
            }
        }

        public void Import(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach(order =>
                {
                    if (!orders.Contains(order))
                    {
                        orders.Add(order);
                    }
                });
            }
        }

        public object QueryByTotalAmount(float amout)
        {
            using (var context = new MysqlContext())
            {
                var query = context.Orders.Where(order => order.TotalPrice >= amout)
               .OrderByDescending(o => o.TotalPrice)
               .ToList();
                return query;
            }
        }
    }
}
