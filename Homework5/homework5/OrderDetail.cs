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
        public int totalPrice;

        public OrderDetail(List<Goods> goods)
        {
            this.goods = goods;
            foreach (Goods goods1 in goods)
            {
                this.totalPrice = goods1.count * goods1.price;
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
        public string name;
        public int count;
        public int price;
        public Goods(string name,int count,int price)
        {
            this.count = count;
            this.name = name;
            this.price = price;
        }
        public override string ToString()
        {
            return "\n name："+name+"   price："+price+"   count"+ count;
        }
    }
}