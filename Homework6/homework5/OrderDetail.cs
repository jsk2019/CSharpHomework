using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    public class OrderDetail
    {
        public List<Goods> goods = new List<Goods>();
        public int totalPrice { get; set; }

        public OrderDetail() { }
        public OrderDetail(List<Goods> goods)
        {
            this.goods = goods;
            foreach (Goods goods1 in goods)
            {
                this.totalPrice += goods1.count * goods1.price;
            }
        }

        public override string ToString()
        {
            String goodsInfo = "";
            foreach (Goods goods1 in goods)
            {
                goodsInfo = goodsInfo + goods1.ToString() + "\n";
            }
            return goodsInfo;
        }
    }
    public class Goods
    {
        public string name { get; set; }
        public int count { get; set; }
        public int price { get; set; }
        public Goods() { }
        public Goods(string name,int count,int price)
        {
            this.count = count;
            this.name = name;
            this.price = price;
        }
        public Goods(string name)
        {

            this.name = name;
        }
        public override string ToString()
        {
            return "\n name："+name+"   price："+price+"   count"+ count;
        }
    }
}