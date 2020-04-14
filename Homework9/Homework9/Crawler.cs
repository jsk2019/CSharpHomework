using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Homework9
{
    public class Crawler
    {
        public delegate void InformEventHandler(object o, InformEventArgs e);
        public class InformEventArgs : EventArgs
        {
            public string Url { get; set; }
            public string Message { get; set; }
        }
        public Queue urls = new Queue();
        private int count = 0;
        public string StartURL{get;set;}
        public event InformEventHandler Inform;


        public Crawler()
        {
            this.urls = new Queue();
            this.count = 0;
        }
        public void Crawl()
        {
            Inform(this, new InformEventArgs() { Url = StartURL, Message = "开始爬取" });
            while (true)
            {
                string current = null;

                if (urls.Count != 0)
                {
                    Object obj = urls.Dequeue();
                    current = obj + "";
                    StartURL = current;
                }
                if (current == null || count > 10) break;
                string html = DownLoad(current); // 下载
                count++;
                Inform(this, new InformEventArgs() { Url = StartURL, Message = "爬取中，请稍等" });
                if (count > 1)
                {
                    if (current.Substring(current.Length - 4, 4) == "html") { Parse(html, current); }//解析,并加入新的链接
                }
                else
                {
                    Parse(html, current);
                    Inform(this, new InformEventArgs() { Url = null, Message = "爬行结束" });
                }
                Inform(this, new InformEventArgs() { Url = null, Message = "爬行结束" });
            }
        }
            private string DownLoad(string url)
            {
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.Encoding = Encoding.UTF8;
                    string html = webClient.DownloadString(url);
                    string fileName = count.ToString();
                    File.WriteAllText(fileName, html, Encoding.UTF8);
                    return html;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return "";
                }
            }

            private void Parse(string html, string current)
            {
                string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
                MatchCollection matches = new Regex(strRef).Matches(html);
                foreach (Match match in matches)
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                              .Trim('"', '\"', '#', '>');
                    if (strRef.Length == 0) continue;

                    //  if (strRef.Substring(0, 1) == "/") { strRef = current.Substring(0,current.Length-1) + strRef; }
                    if (strRef.Substring(0, 1) == "/") { strRef = "https://www.cnblogs.com" + strRef; }
                    urls.Enqueue(strRef);
                }
            }
        }
    }
