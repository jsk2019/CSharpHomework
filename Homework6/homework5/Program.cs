using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
     class Program
    {
        static void Main(string[] args)
        {
            List<Goods> listgoods1 = new List<Goods>();
            Goods goods1 = new Goods("book", 5, 10);
            Goods goods2 = new Goods("bag", 1, 500);
            listgoods1.Add(goods1);
            listgoods1.Add(goods2);
            InfoList.list.Add(new Order("001", "jsk", new OrderDetail(listgoods1)));
            
        }
    }
}
