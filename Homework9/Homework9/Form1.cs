using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework9
{
    public partial class Form1 : Form
    {
        public Crawler crawler = new Crawler();
        public Form1()
        {
            InitializeComponent();
            crawler.Inform += Crawler_PageDownloaded;
            MesBox.DataBindings.Add("Text", crawler, "StartURL");
            
        }
        private void Crawler_PageDownloaded(object obj,Crawler.InformEventArgs e)
        {
            if (this.MesBox.InvokeRequired)
            {
                Action<Crawler.InformEventArgs> action = this.AddResult;
                this.Invoke(action,e);
            }
            else
            {
                AddResult(e);
            }
        }
        private void startBtn_Click(object sender, EventArgs e)
        {
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            crawler.urls.Enqueue(startUrl);
            crawler.StartURL = startUrl;
            new Thread(crawler.Crawl).Start();
        }

        private void AddResult(Crawler.InformEventArgs e)
        {
            if (e.Url == null)
            {
                MesBox.Items.Add(e.Message);
            }
            else
            {
                MesBox.Items.Add("爬取网址：" + e.Url + e.Message);
            }
        }
    }
}
