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
    public partial class Form2 : Form
    {
        //public Order orderModify;
        public List<OrderItem> orderItems = new List<OrderItem>();
        
        public Form2(string ID, string name, List<OrderItem> orderItems)
        {
            InitializeComponent();
            this.IDInput.Text = ID;
            this.NameInput.Text = name;
            this.orderItems = orderItems;
            orderItemBindingSource.DataSource = orderItems;
            IDInput.Visible = false;

        }
        public Form2()
        {
            InitializeComponent();
           
            orderItemBindingSource.DataSource = orderItems;
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            double.TryParse(goodsPrice.Text, out double price);
            uint.TryParse(goodCount.Text, out uint count);
            orderItems.Add(new OrderItem(goodsName.Text,price,count));
            orderItemBindingSource.ResetBindings(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint.TryParse(IDInput.Text, out uint orderID);
            Order orderModify = new Order(orderID,NameInput.Text,orderItems);
            Form1 form1 = (Form1)this.Owner;
            form1.newOrder = orderModify;
            this.Close();
        }
       
    }
}
