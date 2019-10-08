using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixLib
{
    /// <summary>
    /// Represents a class providing event handler
    /// </summary>
    public class EventHandler
    {
        /// <summary>
        /// Generates new message on event occurs
        /// </summary>
        /// <param name="arg">Event arguments</param>
        internal void OnNewMessage(MatrixEventArgs arg)
        {
            MessageBox.Show($"Element changed on index [{arg.I}, {arg.J}].");
        }
    }
}
