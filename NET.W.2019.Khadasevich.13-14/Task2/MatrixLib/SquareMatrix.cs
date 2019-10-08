using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    /// <summary>
    /// A class that represents square matrix
    /// </summary>
    /// <typeparam name="T">Type of matrix elements</typeparam>
    public class SquareMatrix<T>
    {
        #region Fields
        /// <summary>
        /// A field to hold matrix size
        /// </summary>
        internal int size;

        /// <summary>
        /// An array that holds matrix elements
        /// </summary>
        protected T[,] matrix;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class
        /// </summary>
        public SquareMatrix()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class with specified sizeS
        /// </summary>
        /// <param name="size">Size of matrix</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when matrix size is less or equal to 0</exception>
        public SquareMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("Size of the matrix must be greater than  0.");
            }

            EventHandler handler = new EventHandler();
            OnElementChanging += handler.OnNewMessage;

            matrix = new T[size, size];
            this.size = size;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}{T}"/> class
        /// </summary>
        /// <param name="matrix">Matrix elements</param>
        /// <exception cref="ArgumentNullException">Thrown when matrix is null </exception>
        /// <exception cref="ArgumentException">Thrown when specified matrix doesn't match the type</exception>
        public SquareMatrix(T[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("Matrix is not initialized.");
            }

            if (matrix.Length == 0)
            {
                throw new ArgumentNullException("Matrix is not initialized.");
            }

            if (!IsSquareMatrix(matrix))
            {
                throw new ArgumentException("Specified matrix doesn't match the type.");
            }

            EventHandler handler = new EventHandler();
            OnElementChanging += handler.OnNewMessage;

            this.matrix = matrix;
            size = matrix.GetLength(0);
        }

        #endregion

        #region Delegates

        /// <summary>
        /// Delegate type whose type must matches receiver's method
        /// </summary>
        /// <param name="e">Message arguments</param>
        private delegate void MsgEventHandler(MatrixEventArgs e);

        /// <summary>
        /// Occurs when matrix element has been changed
        /// </summary>
        private event MsgEventHandler OnElementChanging;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets current matrix
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when specified matrix doesn't match the type</exception>
        public virtual T[,] Matrix
        {
            get
            {
                return matrix;
            }

            set
            {
                if (!IsSquareMatrix(value))
                {
                    throw new ArgumentException("Specified matrix doesn't match the type.");
                }

                matrix = value;
            }
        }

        /// <summary>
        /// Gets matrix size
        /// </summary>
        public int Size
        {
            get
            {
                return size;
            }
        }

        /// <summary>
        /// Gets or sets matrix element on specified indexes
        /// </summary>
        /// <param name="i">Row index</param>
        /// <param name="j">Column index</param>
        /// <returns>Matrix element on specified index</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when specified indexes is out of range</exception>
        public T this [int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i > Size || j > Size)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range.");
                }

                return matrix[i, j];
            }

            set
            {
                if (i < 0 || j < 0 || i > Size || j > Size)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range.");
                }

                OnElementChanging?.Invoke(new MatrixEventArgs(i, j));
                matrix[i, j] = value;
            }
        }

        #endregion

        #region Public API

        /// <summary>
        /// Checks if specified matrix matches the square matrix type
        /// </summary>
        /// <param name="matrix">Specified matrix</param>
        /// <returns>True if matrix is square. False otherwise</returns>
        public static bool IsSquareMatrix(T[,] matrix)
        {
            if (matrix == null)
            {
                return false;
            }

            if (matrix.Length == 0)
            {
                return false;
            }

            return matrix.GetLength(0) == matrix.GetLength(1);
        }

        #endregion
    }
}
