using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    /// <summary>
    /// Represents a class providing <see cref="SquareMatrix{T}"/> class extension
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Summarizes two matrix
        /// </summary>
        /// <typeparam name="T">Type of matrix elements</typeparam>
        /// <param name="firstMatrix">First matrix</param>
        /// <param name="secondMatrix">Second matrix</param>
        /// <returns>Sum of two matrix</returns>
        /// <exception cref="ArgumentNullException">Thrown when one of the matrix is null</exception>
        /// <exception cref="ArgumentException">Thrown when matrix have different sizes</exception>
        /// <exception cref="InvalidOperationException">Thrown when first matrix type doesn't match second matrix type</exception>
        public static SquareMatrix<T> Sum<T>(this SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
        {
            if (firstMatrix == null || secondMatrix == null)
            {
                throw new ArgumentNullException("Matrix is null.");
            }

            if (firstMatrix.Size != secondMatrix.Size)
            {
                throw new ArgumentException("Matrixes sizes don't match.");
            }

            SquareMatrix<T> resultantMatrix = new SquareMatrix<T>(firstMatrix.Size);

            try
            {
                for (int i = 0; i < resultantMatrix.Size; i++)
                {
                    for (int j = 0; j < resultantMatrix.Size; j++)
                    {
                        resultantMatrix[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
                    }
                }
            }
            catch
            {
                throw new InvalidOperationException("First matrix type doesn't match second matrix type.");
            }

            return resultantMatrix;
        }
    }
}
