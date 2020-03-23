using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace homework5.OrderServiceTests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void StartTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ShowInfoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddInfoTest()
        {
            List<Goods> listgoods1 = new List<Goods>();
            Goods goods1 = new Goods("abc",2, 2);
            listgoods1.Add(goods1);
            InfoList.list.Add(new Order("005", "Jordan", new OrderDetail(listgoods1)));
            Assert.IsTrue(InfoList.list[0].ID == "005" && InfoList.list[0].customer == "Jordan"&&InfoList.list[0].orderDetail.goods[0].name=="abc");
            Assert.IsFalse(InfoList.list[0].orderDetail.totalPrice == 8);
        }

        [TestMethod()]
        public void SearchInfoTest()
        {
            List<Goods> listgoods1 = new List<Goods>();
            Goods goods1 = new Goods("abc", 2, 2);
            listgoods1.Add(goods1);
            InfoList.list.Add(new Order("001", "Jordan", new OrderDetail(listgoods1)));
            Assert.AreEqual(OrderService.SearchInfo(1,"001"), new Order("001", "Jordan", new OrderDetail(listgoods1)));


        }

        [TestMethod()]
        public void DeleteInfoTest()
        {
            List<Goods> listgoods1 = new List<Goods>();
            Goods goods1 = new Goods("abc", 2, 2);
            listgoods1.Add(goods1);
            InfoList.list.Add(new Order("001", "Jordan", new OrderDetail(listgoods1)));
            Assert.IsFalse(OrderService.DeleteInfo("002"));
            Assert.IsTrue(OrderService.DeleteInfo("001"));
        }

        [TestMethod()]
        public void ReviseInfoTest()
        {
            List<Goods> listgoods1 = new List<Goods>();
            Goods goods1 = new Goods("abc", 2, 2);
            listgoods1.Add(goods1);
            InfoList.list.Add(new Order("001", "Jordan", new OrderDetail(listgoods1)));
            OrderService.ReviseInfo("001", "abc", 5);
            Assert.IsTrue(InfoList.list[0].orderDetail.goods[0].count == 5);
        }

        [TestMethod()]
        public void ExportTest()
        {

            List<Goods> listgoods1 = new List<Goods>();
            Goods goods1 = new Goods("abc", 2, 2);
            listgoods1.Add(goods1);
            InfoList.list.Add(new Order("001", "Jordan", new OrderDetail(listgoods1)));
            OrderService.Import();
            OrderService.Export();
            List<Goods> goodList = new List<Goods>();
            Assert.AreEqual(OrderService.Import()[0].ID,InfoList.list[0].ID);
            Assert.AreEqual(OrderService.Import()[0].customer, InfoList.list[0].customer);
            Assert.AreEqual(OrderService.Import()[0].orderDetail.totalPrice, InfoList.list[0].orderDetail.totalPrice);
        }

        [TestMethod()]
        public void ImportTest()
        {
            List<Goods> listgoods1 = new List<Goods>();
            Goods goods1 = new Goods("abc", 2, 2);
            listgoods1.Add(goods1);
            InfoList.list.Add(new Order("001", "Jordan", new OrderDetail(listgoods1)));
            OrderService.Import();
            OrderService.Export();
            List<Goods> goodList = new List<Goods>();
            Assert.AreEqual(OrderService.Import()[0].ID, InfoList.list[0].ID);
            Assert.AreEqual(OrderService.Import()[0].customer, InfoList.list[0].customer);
            Assert.AreEqual(OrderService.Import()[0].orderDetail.totalPrice, InfoList.list[0].orderDetail.totalPrice);
        }
    }
}