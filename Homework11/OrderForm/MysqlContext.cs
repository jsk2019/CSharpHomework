using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderForm
{
    public class MysqlContext : DbContext
    {
        public MysqlContext() : base("OrderDataBase")
        {
            Database.SetInitializer(
        new DropCreateDatabaseIfModelChanges<MysqlContext>());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Customer> Customers { get; set; }
        //public DbSet<user> Blogs { get; set; }
    }


}
