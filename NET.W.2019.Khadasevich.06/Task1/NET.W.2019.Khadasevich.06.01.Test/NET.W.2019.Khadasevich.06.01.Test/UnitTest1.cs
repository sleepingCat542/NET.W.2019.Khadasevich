using System;

using NUnit.Framework;

namespace NET.W._2019.Khadasevich._06._01.Test
{

    
        [TestFixture]
        public class PolynomialTests
        {
            [Test]
            public void Constructor_EmptyArray_ArgumentException()
                => Assert.Throws<ArgumentException>(() => new Polynomial(new int[0]));

            [Test]
            public void Constructor_NullArray_ArgumentException()
                => Assert.Throws<ArgumentNullException>(() => new Polynomial(null));

            [TestCaseSource("SamePolynomials")]
            public void GetHashCode_SamePolynomials_EqualsHashCodes(int[] coefficients1, int[] coefficients2)
            {
                Assert.That(new Polynomial(coefficients1).GetHashCode(), Is.EqualTo(new Polynomial(coefficients2).GetHashCode()));
            }


            [Test]
            public void GetHashCode_DifferentPolynomials_DifferentHashCodes()
            {
                var p1 = new Polynomial(new int[] { 1, 2, 3 });
                var p2 = new Polynomial(new int[] { 1, 2, 0 });
                Assert.AreNotEqual(p1.GetHashCode(), p2.GetHashCode());
            }

            [TestCaseSource("SamePolynomials")]
            public void Equals_SamePolynomials_True(int[] coefficients1, int[] coefficients2)
            {
                var p1 = new Polynomial(coefficients1);
                var p2 = new Polynomial(coefficients2);

                Assert.That(p1.Equals(p2), Is.True);
                Assert.That(p1.Equals((object)p2), Is.True);
                Assert.That(p2.Equals(p1), Is.True);
                Assert.That(p1 == p2, Is.True);
            }

            [Test]
            public void Equals_NullParameter_False()
            {
                var p1 = new Polynomial(new int[] { 1 });
                Polynomial p2 = null;

                Assert.That(p1.Equals(p2), Is.False);
                Assert.That(p1.Equals((object)p2), Is.False);
            }

            [TestCaseSource("AdditionParametersCases")]
            public void PlusOperator_ValidData_Sum(int[] coefficents1, int[] coefficents2, int[] expectedResult)
            {
                var p1 = new Polynomial(coefficents1);
                var p2 = new Polynomial(coefficents2);
                var result = p1 + p2;

                CollectionAssert.AreEqual(result.coefficientsOfPolynomial, expectedResult);
            }
            
            [TestCaseSource("SubtractionParametersCases")]
            public void MinusOperator_ValidData_ValidResult(int[] coefficents1, int[] coefficents2, int[] expectedResult)
            {
                var p1 = new Polynomial(coefficents1);
                var p2 = new Polynomial(coefficents2);
                var result = p1 - p2;

                CollectionAssert.AreEqual(result.coefficientsOfPolynomial, expectedResult);
            }
            

            [TestCaseSource("MultiplicationParametersCases")]
            public void MultiplyOperator_ValidData_Composition(int[] coefficents1, int[] coefficents2, int[] expectedResult)
            {
                var p1 = new Polynomial(coefficents1);
                var p2 = new Polynomial(coefficents2);
                var result = p1 * p2;

                CollectionAssert.AreEqual(result.coefficientsOfPolynomial, expectedResult);
            }
      

            [TestCase(new int[] { 1, 2, 3 }, "x^2 + 2*x + 3")]
            [TestCase(new int[] { 0 }, "")]
            [TestCase(new int[] { 1 }, "1")]
            [TestCase(new int[] { 1, 2, 0, 3 }, "x^3 + 2*x^2 + 3")]
            [TestCase(new int[] { 1, 2, 0, 0 }, "x^3 + 2*x^2")]
            public static void ToString_ValidData_StringReprezentation(int[] coefficients, string expectedResult)
            {
                var p = new Polynomial(coefficients);

                Assert.That(p.ToString(), Is.EqualTo(expectedResult));
            }

            public static object[] SamePolynomials =
            {
            new object[] {new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 } },
            new object[] {new int[] { 0, 1, 2 }, new int[] { 1, 2 } },
            new object[] {new int[] { 0 }, new int[] { 0 } }
        };

            public static object[] AdditionParametersCases =
            {
            new object[] {new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 2, 4, 6 } },
            new object[] {new int[] { -1, -3, 4 }, new int[] { 1, 2, 0 }, new int[] { 0, -1, 4 } },
            new object[] {new int[] { 1 }, new int[] { 1 }, new int[] { 2 } },
            new object[] {new int[] { 1 }, new int[] { 0 }, new int[] { 1 } },
            new object[] {new int[] { 0 }, new int[] { 5, 2, 1 }, new int[] { 5, 2, 1 } }
        };

            public static object[] SubtractionParametersCases =
            {
            new object[]{ new int[] { 1 }, new int[] { 1 }, new int[] { 0 } },
            new object[] { new int[] { 1, 2, 3 }, new int[] { 2 }, new int[] { 1, 2, 1 } },
            new object[] { new int[] { 5, 5, 5 }, new int[] { 1, 2, 3 }, new int[] { 4, 3, 2 } },
            new object[] { new int[] { 1, 2, 3 }, new int[] { 0 }, new int[] { 1, 2, 3 } },
            new object[] { new int[] { 0 }, new int[] { 5, 2, 1 }, new int[] { -5, -2, -1 } },
            new object[] { new int[] { 2, 3, 4 }, new int[] { 3, 4, 5 }, new int[] { -1, -1, -1 } }
        };

            public static object[] MultiplicationParametersCases =
            {
            new object[] {new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, new int[] { 1, 4, 10, 12, 9 } },
            new object[] {new int[] { -1, -3, 4 }, new int[] { 1 }, new int[] { -1, -3, 4 } },
            new object[] {new int[] { -1, -3, 4 }, new int[] { 1, 2, 3 }, new int[] { -1, -5, -5, -1, 12 } },
            new object[] {new int[] { 1 }, new int[] { 1 }, new int[] { 1 } },
            new object[] {new int[] { 1 }, new int[] { 0 }, new int[] { 0 } },
            new object[] {new int[] { 0 }, new int[] { 5, 2, 1 }, new int[] { 0, 0, 0 } }
        };
        }
    }

