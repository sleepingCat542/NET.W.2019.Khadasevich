using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Khadasevich._11._02
{
    /// <summary>
    /// Class provides data for event
    /// </summary>
    public class ClockEventArgs: EventArgs
    {
        private int TimeToWait;

        public ClockEventArgs(int time)
        {
            this.TimeToWait = time;
        }

        public DateTime Date { get; set; } = DateTime.Now;

        public int TimeToWaitProperty
        {
            get => this.TimeToWait;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Time should be greater than 0");
                }

                this.TimeToWait = value;
            }
        }
    }
}

