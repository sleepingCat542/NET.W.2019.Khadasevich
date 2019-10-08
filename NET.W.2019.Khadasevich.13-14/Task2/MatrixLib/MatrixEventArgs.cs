using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    /// <summary>
    /// A class that represents events arguments
    /// </summary>
    public class MatrixEventArgs : EventArgs
    {
        #region Fields

        /// <summary>
        /// A field to hold row index of the changed element
        /// </summary>
        private readonly int i;

        /// <summary>
        /// A field to hold column index of the changed element
        /// </summary>
        private readonly int j;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixEventArgs"/> class
        /// </summary>
        /// <param name="i">Row index of the changed element</param>
        /// <param name="j">Column index of the changed element</param>
        public MatrixEventArgs(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets row index of the changed element
        /// </summary>
        public int I
        {
            get
            {
                return this.i;
            }
        }

        /// <summary>
        /// Gets column index of the changed element
        /// </summary>
        public int J
        {
            get
            {
                return this.j;
            }
        }

        #endregion
    }
}
