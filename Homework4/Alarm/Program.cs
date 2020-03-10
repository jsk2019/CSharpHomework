using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Homework4._2
{
     public delegate void ClockEventHandler(Object sender, ClockArgs arg);
    public class ClockArgs
    {
        public int time;
        public int Time{get;set;}
        public void NextTime()
        {
            Time += 1;
        }
    }

    public class Clock
    {
        public event ClockEventHandler TickEvent;
        public event ClockEventHandler AlarmEvent;
        private int times;
        public Clock(int times)
        {
            this.times = times;
            TickEvent += (object sender, ClockArgs arg) => { };
        }
        public void work()
        {
            Console.WriteLine($"开始执行{DateTime.Now}");
            ClockArgs clockArgs = new ClockArgs();
            while(clockArgs.Time<times)
            {
                clockArgs.NextTime();
                Thread.Sleep(1000);
                TickEvent(this, clockArgs);
            }
            AlarmEvent(this, clockArgs);
        }
    }
        class Program
        {
            static void Main(string[] args)
            {
            Console.WriteLine("请输入你设置的闹钟：");
            bool boolTime = int.TryParse(Console.ReadLine(), out int setTime);
            Clock clock = new Clock(setTime);
            clock.TickEvent += (Object sender, ClockArgs arg) =>
              {
                  Console.WriteLine($"Tick!{DateTime.Now}");
              };
            clock.AlarmEvent += (Object sender, ClockArgs arg) =>
              {
                  Console.WriteLine($"Alarm!{DateTime.Now}");
              };
            clock.work();
            }
        }
    }