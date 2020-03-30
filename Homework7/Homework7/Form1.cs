using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private string color = "";
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(this.depth.Text, out int depth);
            int.TryParse(this.mainLength.Text, out int length);
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(depth, 250, 300, length, -Math.PI / 2);
        }

        void drawCayleyTree(int n ,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            int.TryParse(this.rightAngle.Text, out int rightAngle);
            double th1=rightAngle * Math.PI / 180;
            int.TryParse(this.leftAngle.Text, out int leftAngle);
            double th2 = leftAngle * Math.PI / 180;
            double.TryParse(this.rightLength.Text, out double rightLength);
            double per1 = rightLength;
            double.TryParse(this.leftLength.Text, out double leftLength);
            double per2 = leftLength;
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1* leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics = this.panel1.CreateGraphics();

            if (color == "红色") graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
            if (color == "黑色") graphics.DrawLine(Pens.Black, (int)x0, (int)y0, (int)x1, (int)y1);
            if (color == "蓝色") graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
        }
       

        private void clearButton_Click(object sender, EventArgs e)
        {
            graphics.Clear(this.BackColor);
        }

        private void colorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            color = this.colorComboBox.Text;
        }
    }
}
