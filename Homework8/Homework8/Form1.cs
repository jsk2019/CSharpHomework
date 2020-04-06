using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework8
{
    public partial class Form1 : Form
    {
        public OrderService os = new OrderService();
        public Order newOrder { get; set; }
        public String orderID { get; set; }
        public Form1(Order order)
        {
            os.AddOrder(order);
        }
        public Form1()
        {
            InitializeComponent();
            OrderItem apple = new OrderItem("apple", 10.0, 80);
            OrderItem egg = new OrderItem("eggs", 1.2, 200);
            OrderItem milk = new OrderItem("milk", 50, 10);

            Order order1 = new Order(1, "Customer1", new List<OrderItem> { apple, egg, milk });
            Order order2 = new Order(2, "Customer2", new List<OrderItem> { egg, milk });
            Order order3 = new Order(3, "Customer3", new List<OrderItem> { apple, milk });

            // OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);

            OrderbindingSource.DataSource = os.Orders;
            indexTextBox.DataBindings.Add("Text", this, "orderID");
        }

        private void indexButton_Click(object sender, EventArgs e)
        {
            uint.TryParse(orderID, out uint result);
            OrderbindingSource.DataSource = os.Orders.Where(s => s.OrderId == result);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Order currentOrder = (Order)OrderbindingSource.Current;
            os.RemoveOrder(currentOrder.OrderId);
            orderItemBindingSource.ResetBindings(false);
        }

        



        private void modifyButton_Click(object sender, EventArgs e)
        {
            Order currentOrder = (Order)OrderbindingSource.Current;
            string id = "" + currentOrder.OrderId;
            string name = currentOrder.Customer;
            List<OrderItem> orderItems = currentOrder.Items;
            this.dataGridView1.Rows.Remove(this.dataGridView1.SelectedRows[0]);
            os.RemoveOrder(currentOrder.OrderId);
            orderItemBindingSource.ResetBindings(false);   
            Form2 form2 = new Form2(id,name,orderItems);
            form2.Owner = this;
            form2.ShowDialog();
            os.Orders.Add(newOrder);
            MessageBox.Show(newOrder.ToString());
            OrderbindingSource.DataSource = os.Orders;
            OrderbindingSource.ResetBindings(false);


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnModify" && e.RowIndex >= 0)
            {
                this.Close();
            }
        }



        private void addButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Owner = this;
            form2.ShowDialog();
            os.Orders.Add(newOrder);
            MessageBox.Show(newOrder.ToString());
            OrderbindingSource.DataSource = os.Orders;
            OrderbindingSource.ResetBindings(false);
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            os.Export("testExport");
            MessageBox.Show("导出成功！");
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            os.Import("E://Homework8//Homework8//bin//Debug//testExport");
            OrderbindingSource.DataSource = os.Orders;
            OrderbindingSource.ResetBindings(false);
            MessageBox.Show("导入成功");
        }
    }
}
