using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Khadasevich._11._02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите данные:\nчасы:");
            int hours = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("минуты");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("секунды:");
            int sec = Convert.ToInt32(Console.ReadLine());
            Clock clock1 = new Clock(hours, min, sec);

            ClockHandler handler1 = new ClockHandler();
            ClockHandler handler2 = new ClockHandler();
            ClockHandler handler3 = new ClockHandler();

            clock1.ClockTick += handler1.ShowMessage;
            clock1.ClockTick += handler2.ShowMessage;
            clock1.ClockTick += handler3.ShowMessage;

            clock1.Start();

            Console.ReadKey();
        }
    }
}
