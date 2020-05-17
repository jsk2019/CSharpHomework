using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using OrderWeb.Dao;
using OrderWeb.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace OrderWeb.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class OrderService : ControllerBase
    {
        private readonly OrderContext orderDb;

        public OrderService(OrderContext context)
        {
            this.orderDb = context;
        }


        [HttpGet("{id}")]
        public ActionResult<Order> GetAllOrder(String id)
        {
            var order = orderDb.Orders.FirstOrDefault(t=>t.Id == id);
            if(order == null){
              return NotFound();
            }
            else {
              return order;
            }
        }

        [HttpPost]
        public ActionResult<Order> AddOrder(Order order)
        {
            try
            {
                orderDb.Orders.Add(order);
                orderDb.SaveChanges();
            }
            catch (Exception error)
            {                
                return BadRequest(error.InnerException.Message);
            }
            return order;
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(string id){
           try
            {
                var order = orderDb.Orders.FirstOrDefault(t => t.Id == id);
                if (order != null)
                {
                    orderDb.Remove(order);
                    orderDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

         [HttpPut("{id}")]
        public ActionResult<Order> PutOrder(string id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                orderDb.Entry(order).State = EntityState.Modified;
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        [HttpGet("/getAll")]
        public IQueryable<Order> GetAllOrder(){
          var order = orderDb.Orders.Include(o=>o.Items.Select(i=>i.GoodsItem)).Include("Customer");        
            return order;
        }  
        
        
    }
}
