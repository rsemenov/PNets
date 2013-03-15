namespace PNets.Core
{
    public static class MathExtensions
    {
        public static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public static int LCM(int a, int b)
        {
            return a / GCD(a, b) * b;
        }
    }
}