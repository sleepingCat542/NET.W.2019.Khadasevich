using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Khadasevich._11._02
{
    /// <summary>
    /// Class listener
    /// </summary>
    public class ClockHandler
    {
        public string Name;
        private static int CountOfListeners=1;

        public ClockHandler()
        {
            this.Name = $"Listener {CountOfListeners++}";
        }


        public void ShowMessage(object sender, ClockEventArgs e)
        {
            Console.WriteLine($"Привет {this.Name}! Сегодня {e.Date.ToShortDateString()}.");
        }
    }
}
