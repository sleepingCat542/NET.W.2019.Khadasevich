using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    /// <summary>
    /// A class that represents diagonal matrix
    /// </summary>
    /// <typeparam name="T">Type of matrix elements</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class with specified size
        /// </summary>
        /// <param name="size">Size of the matrix</param>
        public DiagonalMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class
        /// </summary>
        /// <param name="matrix">Matrix elements</param>
        /// <exception cref="ArgumentNullException">Thrown when matrix is null </exception>
        /// <exception cref="ArgumentException">Thrown when specified matrix doesn't match the type</exception>
        public DiagonalMatrix(T[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("Matrix is not initialized.");
            }

            if (matrix.Length == 0)
            {
                throw new ArgumentNullException("Matrix is not initialized.");
            }

            if (!IsDiagonalMatrix(matrix))
            {
                throw new ArgumentException("Specified matrix doesn't match the type.");
            }

            this.matrix = matrix;
            this.size = matrix.GetLength(0);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets current matrix
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when specified matrix doesn't match the type</exception>
        public override T[,] Matrix
        {
            get
            {
                return this.matrix;
            }

            set
            {
                if (!IsDiagonalMatrix(value))
                {
                    throw new ArgumentException("Specified matrix doesn't match the type.");
                }

                this.matrix = value;
            }
        }

        #endregion

        #region Public API

        /// <summary>
        /// Checks if specified matrix matches the diagonal matrix type
        /// </summary>
        /// <param name="matrix">Specified matrix</param>
        /// <returns>True if matrix is diagonal. False otherwise</returns>
        public static bool IsDiagonalMatrix(T[,] matrix)
        {
            if (matrix == null)
            {
                return false;
            }

            if (matrix.Length == 0)
            {
                return false;
            }

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return false;
            }

            int size = matrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != j && !Equals(matrix[i,j], default(T)))
                    {
                        T t = matrix[i, j];
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion
    }
}
