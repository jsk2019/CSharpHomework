using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("OrderDataBase")
        {
            Database.SetInitializer(
        new DropCreateDatabaseIfModelChanges<OrderContext>());
        }

        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Goods> goods { get; set; }
        public DbSet<Customer> customers { get; set; }
    }

}
