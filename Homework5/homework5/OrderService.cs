using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{

    class OrderService
    {
        public static void Start()
        {
            Console.WriteLine("请选择操作：1.查询所有订单 2.增加订单 3.删除订单 4.修改订单");
            string choose = Console.ReadLine();
            if (choose == "1") OrderService.SearchInfo();
            else if (choose == "2") OrderService.AddInfo();
            else if (choose == "3") OrderService.DeleteInfo();
            else if (choose == "4") OrderService.ReviseInfo();
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
        public static string SearchInfo()
        {
            Console.WriteLine("请输入你要查询的内容序号：1.订单号 2.客户名");
            string choose = Console.ReadLine();
            if (choose == "1")
            {
                Console.WriteLine("请输入订单号:");
                string choose1 = Console.ReadLine();
                var result = from s in InfoList.list
                             where s.ID == choose1
                             orderby s.orderDetail.totalPrice
                             select s;
                List<Order> infos = result.ToList();
                return infos[0].ToString();
            }
            else if (choose == "2")
            {
                Console.WriteLine("请输入客户名:");
                string choose2 = Console.ReadLine();
                var result = InfoList.list.Where(s => s.customer == choose2).OrderBy(s => s.orderDetail.totalPrice);
                List<Order> info = result.ToList();
                return info[0].ToString();
            }
            else
            {
                return "查询失败";
            }
        }
        //删除订单
        public static Boolean DeleteInfo()
        {
            Console.WriteLine("请输入需要删除订单的订单号：");
            string choose = Console.ReadLine();
            int count = InfoList.list.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if (InfoList.list[i].ID == choose)
                {
                    InfoList.list.Remove(InfoList.list[i]);
                    return true;
                }
            }
            return false;
        }
        //修改订单
        public static Boolean ReviseInfo()
        {
            Console.WriteLine("请输入需要修改订单的订单号：");
            string choose = Console.ReadLine();
            int count = InfoList.list.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if (InfoList.list[i].ID == choose)
                {
                    Console.WriteLine("请输入修改顾客姓名");
                    string customer = Console.ReadLine();
                    Console.WriteLine("请输入货物类型");
                    string goods = Console.ReadLine();
                    Console.WriteLine("请输入修改后的该货物数量");
                    int count2 = int.Parse(Console.ReadLine());
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
                    OrderDetail info = new OrderDetail(InfoList.list[i].orderDetail.goods);
                    Order order = new Order(InfoList.list[i].ID, InfoList.list[i].customer, info);
                    InfoList.list.Remove(InfoList.list[i]);
                    foreach (Order x in InfoList.list)
                    {
                        if (info.Equals(x))
                        {
                            Console.WriteLine("信息重复，请重新填写");
                            return false;
                        }
                    }
                    InfoList.list.Add(order);
                    return true;
                }
                else { Console.WriteLine("无该搜索项"); return false; }
            }
            return false;
        }
    }

}
