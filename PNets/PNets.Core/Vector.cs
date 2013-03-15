using System;

namespace PNets.Core
{
    public class Vector : Matrix
    {
        public Vector(int size)
            : base(1, size)
        {

        }

        public double this[int i]
        {
            get { return base[0, i]; }
            set { base[0, i] = value; }
        }

        public static Vector operator *(int n, Vector v)
        {
            var nv = new Vector(v.cols);
            for (int i = 0; i < v.cols; i++)
            {
                nv[i] = v[i] * n;
            }
            return nv;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            if (a.cols != b.cols)
                throw new ArgumentException("Different vector sizes");

            var nv = new Vector(a.cols);
            for (int i = 0; i < a.cols; i++)
            {
                nv[i] = a[i] + b[i];
            }
            return nv;
        }

    }
}