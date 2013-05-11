using System;

namespace PNets.Core.NetProperties
{
    public static class EnumsConverters
    {
        public static string Convert(this StructurallyBoundness value)
        {
            switch (value)
            {
                case StructurallyBoundness.StructurallyBounded:
                    return "Структурно обмежена";
                case StructurallyBoundness.NotStructurallyBounded:
                    return "Не структурно обмежена";
                default:
                    throw new NotSupportedException();
            }
        }

        public static string Convert(this Boundness value)
        {
            switch (value)
            {
                case Boundness.Bounded:
                    return "Обмежена";
                case Boundness.Unbounded:
                    return "Необмежена";
                default:
                    throw new NotSupportedException();
            }
        }

        public static string Convert(this Conservativeness value)
        {
            switch (value)
            {
                case Conservativeness.Conservative:
                    return "Консервативна";
                case Conservativeness.PartiallyConservative:
                    return "Частково консервативна";
                case Conservativeness.NotConservative:
                    return "Не консервативна";
                default:
                    throw new NotSupportedException();
            }
        }

        public static string Convert(this Repetitiveness value)
        {
            switch (value)
            {
                case Repetitiveness.Repetitive:
                    return "Повторювана";
                case Repetitiveness.PartiallyRepetitive:
                    return "Частково повторювана";
                case Repetitiveness.NotRepetitive:
                    return "Не повторювана";
                default:
                    throw new NotSupportedException();
            }
        }

        public static string Convert(this Consistency value)
        {
            switch (value)
            {
                case Consistency.Consistent:
                    return "Несуперечна";
                case Consistency.PartiallyConsistent:
                    return "Частково несуперечна";
                case Consistency.NotConsistent:
                    return "Суперечна";
                default:
                    throw new NotSupportedException();
            }
        }
    }
}