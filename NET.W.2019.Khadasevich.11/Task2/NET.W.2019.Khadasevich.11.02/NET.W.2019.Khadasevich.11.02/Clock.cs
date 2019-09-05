using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NET.W._2019.Khadasevich._11._02
{
    /// <summary>
    /// Class that provides events
    /// </summary>
    public class Clock
    {

        /// <summary>
        /// Common time
		/// </summary>
        private readonly int TimeToWait;

        private int hoursTime;
        private int minutesTime;
        private int secondsTime;


        /// <summary>
        /// Hours of countdown timer
		/// </summary>
        int Hours
        {
            get => hoursTime;
            set
            {
                if (value < 0 || value > 24)
                    throw new ArgumentOutOfRangeException(nameof(value), "Incorrect value for hour.");

                hoursTime = value;
            }
        }

        /// <summary>
		/// Minutes of countdown timer
		/// </summary>
        int Minutes {
            get => minutesTime;
            set
            {
                if (value < 0 || value > 60)
                    throw new ArgumentOutOfRangeException(nameof(value), "Incorrect value for hour.");

                minutesTime = value;
            }
        }

        /// <summary>
		/// Seconds of countdown timer
		/// </summary>
        int Seconds {
            get => secondsTime;
            set
            {
                if (value < 0 || value > 60)
                    throw new ArgumentOutOfRangeException(nameof(value), "Incorrect value for hour.");

                secondsTime = value;
            }
        }

        /// <summary>
        /// Provides the instance of class <see cref="Clock"/>
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        public Clock(int hours, int minutes, int seconds)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
            this.TimeToWait = (3600 * hours + 60 * minutes + seconds)*1000;
        }


        public event EventHandler<ClockEventArgs> ClockTick;

        /// <summary>
        /// Method starting timer
        /// </summary>
        public void Start()
        {
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(TimeToWait);
                OnClockTick(this, new ClockEventArgs(TimeToWait));
            });

            thread.Start();
        }

        /// <summary>
        /// Methods that calls event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnClockTick(object sender, ClockEventArgs e)
        {
            ClockTick?.Invoke(sender, e);
        }
    }
}
