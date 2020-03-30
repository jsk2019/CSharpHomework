using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace homework5
{

    public class OrderService
    {
        public static void Start()
        {
            Console.WriteLine("请选择操作：1.查询订单 2.增加订单 3.删除订单 4.修改订单");
            string choose = Console.ReadLine();
            if (choose == "1") Console.WriteLine(OrderService.SearchInfo(1,"001"));
            else if (choose == "2") OrderService.AddInfo();
         //   else if (choose == "3") OrderService.DeleteInfo();
          //  else if (choose == "4") OrderService.ReviseInfo();
            else Console.WriteLine("请输入正确格式");
        }
        //显示信息
        public static void ShowInfo()
        {
            foreach (Order info in InfoList.list)
            {
                Console.WriteLine("订单信息");
                Console.WriteLine(info.ToString());
            }
        }
        //添加订单
        public static Boolean AddInfo()
        {
            Console.WriteLine("请输入添加的的订单号");
            string ID = Console.ReadLine();

            Console.WriteLine("请输入顾客姓名");
            string customer = Console.ReadLine();

            Console.WriteLine("添加商品");
            List<Goods> goods = new List<Goods>();
            goods.Add(new Goods("book", 10, 15));
            int totalPrice = 0;
            foreach (Goods goods1 in goods)
            {
                totalPrice += goods1.count * goods1.price;
            }
            OrderDetail info = new OrderDetail(goods);
            Order order = new Order(ID, customer, info);
            foreach (Order x in InfoList.list)
            {
                if (order.Equals(x))
                {
                    return false;
                }
            }
            InfoList.list.Add(order);
            return true;
        }
        //查询订单
        public static Order SearchInfo(int x,string index)
        {
            Console.WriteLine("请输入你要查询的内容序号：1.订单号 2.客户名 3.商品名");
            if (x == 1)
            {
                Console.WriteLine("请输入订单号:");
                //string choose2 = "001";
                var result = from s in InfoList.list
                             where s.ID == index
                             orderby s.orderDetail.totalPrice
                             select s;
                List<Order> infos = result.ToList();
                return infos[0];
            }
            else if (x == 2)
            {
                Console.WriteLine("请输入客户名:");
                var result = InfoList.list.Where(s => s.customer == index).OrderBy(s => s.orderDetail.totalPrice);
                List<Order> info = result.ToList();
                return info[0];
            }
            else if (x == 3)
            {
                Console.WriteLine("请输入货物名:");
                List<Order> info = new List<Order>();
                foreach ( Order order in InfoList.list)
                {
                    // var result = order.orderDetail.goods.Where(s => s.name == choose3).OrderBy(s => s.count);
                    foreach(Goods goods1 in order.orderDetail.goods)
                    {
                        if (goods1.name == index)
                        {
                            info.Add(order);
                        }
                        
                    }
                }
                return info[0];
            }
            else { return null; }
        }
        //删除订单
        public static Boolean DeleteInfo(string index)
        {
            int count = InfoList.list.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if (InfoList.list[i].ID == index)
                {
                    InfoList.list.Remove(InfoList.list[i]);
                    return true;
                }
            }
            return false;
        }
        //修改订单
        //choose 要修改的订单号 customer:顾客姓名  goods 货物类型  count2 货物数量
        public static bool ReviseInfo(string choose,string goods,int count2 )
        {
            int count = InfoList.list.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if (InfoList.list[i].ID == choose)
                {
                    //找到该订单并修改，后面考虑写成一个方法
                    int goodTotalCount = InfoList.list[i].orderDetail.goods.Count;
                    for(int j = goodTotalCount - 1; j >= 0; j--)
                    {
                        if (InfoList.list[i].orderDetail.goods[j].name == goods)
                        {
                            InfoList.list[i].orderDetail.goods[j].count = count2;
                        }
                    }
                    int totalPrice = 0;
                    foreach (Goods goods1 in InfoList.list[i].orderDetail.goods)
                    {
                        totalPrice += goods1.count * goods1.price;
                    }
                    return true;
                }
                else { Console.WriteLine("无该搜索项"); return false; }
            }
            return false;
        }
        //序列化
       
        public static void Export()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("order.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, InfoList.list);
            }
        }

        //反序列化
        public static List<Order> Import()
        {
            using(FileStream fs = new FileStream("order.xml", FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                List<Order> orders = (List<Order>)xmlSerializer.Deserialize(fs);
                foreach(Order order in orders)
                {
                    Console.WriteLine(order.ToString());
                }
                return orders;
            }
        }
    }

}
