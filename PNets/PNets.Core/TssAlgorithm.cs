using System;
namespace PNets.Core
{
    public interface IFindBasisAlgorithm
    {
        Basis Execute(Matrix matrix);
    }

    public class TssAlgorithm : IFindBasisAlgorithm
    {
        public Basis Execute(Matrix matrix)
        {
            var basis = new Basis();
            var row = matrix.GetRow(0);
            for (int i = 0; i < row.rows; i++)
            {
                if (row[i] == 0)
                {
                    var v = new Vector(row.rows);
                    v[i] = 1;
                    basis.Add(v);
                }
                else
                {
                    bool sign = row[i] > 0;
                    for (int j = i + 1; j < row.rows; j++)
                    {
                        if (row[j] != 0 && row[j] > 0 ^ sign)
                        {
                            var lcm = MathExtensions.LCM(Math.Abs((int)row[i]), Math.Abs((int)row[j]));
                            var v = new Vector(row.rows);
                            v[i] = (lcm / Math.Abs((int)row[i]));
                            v[j] = (lcm / Math.Abs((int)row[j]));
                            basis.Add(v);
                        }
                    }
                }
            }

            return ExcecuteRound(matrix, basis, 1);
        }

        private Basis ExcecuteRound(Matrix matrix, Basis basis, int rowIndex)
        {
            var currentRow = matrix.GetRow(rowIndex);
            var currentRes = new Vector(basis.Count);
            for (int i = 0; i < basis.Count; i++)
            {
                currentRes[i] = (int)(basis[i].Transpose() * currentRow)[0, 0];
            }
            var newBasis = Compose(basis, currentRes);
            if (rowIndex == matrix.rows-1)
                return newBasis;
            return ExcecuteRound(matrix, newBasis, rowIndex + 1);
        }

        private Basis Compose(Basis basis, Vector items)
        {
            var newBasis = new Basis();
            for (int i = 0; i < items.rows; i++)
            {
                if (items[i] == 0)
                    newBasis.Add(basis[i]);
                else
                {
                    bool sign = items[i] > 0;
                    for (int j = i + 1; j < items.rows; j++)
                    {
                        if (items[j] != 0 && items[j] > 0 ^ sign)
                        {
                            var lcm = MathExtensions.LCM(Math.Abs((int)items[i]), Math.Abs((int)items[j]));
                            newBasis.Add((lcm / Math.Abs((int)items[i])) * basis[i] + (lcm / Math.Abs((int)items[j])) * basis[j]);
                        }
                    }
                }
            }
            return newBasis;
        }

    }
}