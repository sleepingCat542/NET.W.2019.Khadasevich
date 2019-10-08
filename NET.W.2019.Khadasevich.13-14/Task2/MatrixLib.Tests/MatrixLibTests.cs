using System;
using NUnit.Framework;
using MatrixLib;

namespace MatrixLib.Tests
{
    [TestFixture]
    public class MatrixLibTests
    {
        private static int[,] squareArray = { { 0, 1, 2, 3 }, 
                                              { 0, 1, 2, 3 }, 
                                              { 0, 1, 2, 3 }, 
                                              { 0, 1, 2, 3 } };

        private static int[,] symmetricMatrix = { { 5, 0, 8, 9 },
                                                   { 0, 1, 9, 4 },
                                                   { 8, 9, 2, 6 },
                                                   { 9, 4, 6, 3 } };

        private static int[,] diagonalMatrix = { { 5, 0, 0, 0 },
                                                 { 0, 1, 0, 0 },
                                                 { 0, 0, 2, 0 },
                                                 { 0, 0, 0, 3 } };

        [Test]
        public void SquareMatrixConstructor_Test()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(squareArray);

            Assert.AreEqual(4, matrix.Size);
        }

        [Test]
        public void DiagonalMatrixConstructor_Test()
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(diagonalMatrix);

            Assert.AreEqual(4, matrix.Size);
        }

        [Test]
        public void SymmetricMatrixConstructor_Test()
        {
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(symmetricMatrix);

            Assert.AreEqual(4, matrix.Size);
        }

        [Test]
        public void MatrixSumm_Test()
        {
            int[,] expectedResult = { { 10, 0, 8, 9 },
                                      { 0, 2, 9, 4 },
                                      { 8, 9, 4, 6 },
                                      { 9, 4, 6, 6 } };

            SymmetricMatrix<int> firstMatrix = new SymmetricMatrix<int>(symmetricMatrix);
            DiagonalMatrix<int> secondMatrix = new DiagonalMatrix<int>(diagonalMatrix);

            SquareMatrix<int> actualResult = firstMatrix.Sum<int>(secondMatrix);

            for(int i = 0; i < actualResult.Size; i++)
            {
                for(int j = 0; j < actualResult.Size; j++)
                {
                    Assert.AreEqual(expectedResult[i, j], actualResult[i, j]);
                }
            }
        }

        [Test]
        public void SquareMatrixIdexChange_Test()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(squareArray);

            matrix[0, 0] = 5;
        }

        [TestCase(ExpectedResult = true)]
        public bool IsDiagonalMatrix_SquareMatrix_TrueExptected()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(diagonalMatrix);

            return DiagonalMatrix<int>.IsDiagonalMatrix(matrix.Matrix);
        }

        [TestCase(ExpectedResult = false)]
        public bool IsDiagonalMatrix_SquareMatrix_FalseExptected()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(squareArray);

            return DiagonalMatrix<int>.IsDiagonalMatrix(matrix.Matrix);
        }

        [TestCase(ExpectedResult = true)]
        public bool IsSymmetricMatrix_SquareMatrix_TrueExptected()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(symmetricMatrix);

            return SymmetricMatrix<int>.IsSymmetricMatrix(matrix.Matrix);
        }

        [TestCase(ExpectedResult = false)]
        public bool IsSymmetricMatrix_SquareMatrix_FalseExptected()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(squareArray);

            return SymmetricMatrix<int>.IsSymmetricMatrix(matrix.Matrix);
        }
    }
}
