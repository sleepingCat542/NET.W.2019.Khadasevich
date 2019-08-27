using System;

namespace NET.W._2019.Khadasevich._06._01
{
    public class Polynomial
    {
        public int[] coefficientsOfPolynomial;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="coefficients"> array of polynomial coefficients</param>
        public Polynomial(params int[] coefficients)
        {
            Array.Reverse(coefficients);
            this.coefficientsOfPolynomial = coefficients;
        }


        /// <summary>
        /// maps polynomial to string
        /// </summary>
        public override string ToString()
        {
            string str = "";
            for (int i = coefficientsOfPolynomial.Length - 1; i > 0; i--)
            {
                if (coefficientsOfPolynomial[i] != 0)
                {
                    if (coefficientsOfPolynomial[i] != 1)
                        str += coefficientsOfPolynomial[i] + "x^" + i + " + ";
                    else
                        str += "x^" + i + " + ";
                }
            }
            str += coefficientsOfPolynomial[0];
            return str;
        }


        /// <summary>
        /// to get  hashcode of polynomial
        /// </summary>
        public override int GetHashCode()
        {
            int hashCode = this.coefficientsOfPolynomial.Length * this.coefficientsOfPolynomial.GetHashCode();
            return hashCode;
        }


        /// <summary>
        /// to compare polynomials
        /// </summary>
        /// <param name="obj">  the compared object </param>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Polynomial polinom = obj as Polynomial;
            if (object.ReferenceEquals(this, polinom))
                return true;
            else if (this.coefficientsOfPolynomial.Length != polinom.coefficientsOfPolynomial.Length)
                return false;
            else
            {
                for (int i = 0; i < this.coefficientsOfPolynomial.Length; i++)
                {
                    if (this.coefficientsOfPolynomial[i] != polinom.coefficientsOfPolynomial[i])
                        return false;
                }
            }
            return true;
        }


        /// <summary>
        /// polynomial multiplication
        /// </summary>
        /// <param name="p1">  1st polynomial </param>
        /// <param name="p2">  2nd polynomial </param>
        /// <returns>new polynomial </returns>
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            int[] arr = new int[p1.coefficientsOfPolynomial.Length + p2.coefficientsOfPolynomial.Length - 1];
            for (int i = 0; i < p1.coefficientsOfPolynomial.Length; ++i)
                for (int j = 0; j < p2.coefficientsOfPolynomial.Length; ++j)
                    arr[i + j] += p1.coefficientsOfPolynomial[i] * p2.coefficientsOfPolynomial[j];
            return new Polynomial(arr);
        }


        /// <summary>
        /// subtraction of polynomials
        /// </summary>
        /// <param name="p1">  1st polynomial </param>
        /// <param name="p2">  2nd polynomial </param>
        /// <returns>new polynomial </returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            var resultLength = p1.coefficientsOfPolynomial.Length > p2.coefficientsOfPolynomial.Length ?
                p1.coefficientsOfPolynomial.Length : p2.coefficientsOfPolynomial.Length;
            int[] arr = new int[resultLength];
            for (int i = 0; i < resultLength; i++)
            {
                if (i < p1.coefficientsOfPolynomial.Length && i < p2.coefficientsOfPolynomial.Length)
                {
                    arr[i] = p1.coefficientsOfPolynomial[i] + (p2.coefficientsOfPolynomial[i] * -1);
                }
                else
                {
                    if (i < p1.coefficientsOfPolynomial.Length)
                    {
                        arr[i] = p1.coefficientsOfPolynomial[i];
                    }
                    else
                    {
                        arr[i] = p2.coefficientsOfPolynomial[i] * -1;
                    }
                }
            }

            return new Polynomial(arr);
        }




        /// <summary>
        /// polynomial addition
        /// </summary>
        /// <param name="p1">  1st polynomial </param>
        /// <param name="p2">  2nd polynomial </param>
        /// <returns>new polynomial </returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            var resultLength = p1.coefficientsOfPolynomial.Length > p2.coefficientsOfPolynomial.Length ?
                p1.coefficientsOfPolynomial.Length : p2.coefficientsOfPolynomial.Length;
            int[] arr = new int[resultLength];
            for (int i = 0; i < resultLength; i++)
            {
                if (i < p1.coefficientsOfPolynomial.Length && i < p2.coefficientsOfPolynomial.Length)
                {
                    arr[i] = p1.coefficientsOfPolynomial[i] + (p2.coefficientsOfPolynomial[i]);
                }
                else
                {
                    if (i < p1.coefficientsOfPolynomial.Length)
                    {
                        arr[i] = p1.coefficientsOfPolynomial[i];
                    }
                    else
                    {
                        arr[i] = p2.coefficientsOfPolynomial[i];
                    }
                }
            }

            return new Polynomial(arr);
        }



        public static bool operator ==(Polynomial p1, Polynomial p2)
        {

            return p1.Equals(p2);
        }


        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            return !p1.Equals(p2);
        }
    }

}

