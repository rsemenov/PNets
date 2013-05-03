using System;
using System.Collections.Generic;

namespace PNets.Core
{
    public class Vector : Matrix
    {
        public Vector(int size)
            : base(size, 1)
        {        }

        public double this[int i]
        {
            get { return base[i, 0]; }
            set { base[i, 0] = value; }
        }

        public static Vector operator *(int n, Vector v)
        {
            var nv = new Vector(v.rows);
            for (int i = 0; i < v.rows; i++)
            {
                nv[i] = v[i] * n;
            }
            return nv;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            if (a.rows != b.rows)
                throw new ArgumentException("Different vector sizes");

            var nv = new Vector(a.rows);
            for (int i = 0; i < a.rows; i++)
            {
                nv[i] = a[i] + b[i];
            }
            return nv;
        }

        /* public static bool operator < (Vector a, Vector b)
        {
            if (a.rows != b.rows)
                throw new ArgumentException("Different vector sizes");
            bool f = false;
            for (int i = 0; i < a.rows; i++)
            {
                if (a[i] <= b[i])
                {
                    if (a[i] < b[i])
                        f = true;
                }
                else
                    return false;
            }
            return f;
        }

        public static bool operator ==(Vector a, Vector b)
        {
            if (a.rows != b.rows)
                throw new ArgumentException("Different vector sizes");
            
            for (int i = 0; i < a.rows; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }
         */

    }
}