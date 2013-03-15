namespace PNets.Core
{
    public class TssAlgorithm
    {
        public Basis Execute(PetriNet net)
        {
            var basis = new Basis();

            return ExcecuteRound(net, basis, 0);
        }

        private Basis ExcecuteRound(PetriNet net, Basis basis, int rowIndex)
        {
            var currentRow = net.IncedentMatrix.GetRow(rowIndex);
            var currentRes = new Vector(basis.Count);
            for (int i = 0; i < basis.Count; i++)
            {
                currentRes[i] = (int)(currentRow * basis[i].Transpose())[0, 0];
            }
            var newBasis = Compose(basis, currentRes);
            if (rowIndex == net.IncedentMatrix.rows)
                return newBasis;
            return ExcecuteRound(net, newBasis, rowIndex + 1);
        }

        private Basis Compose(Basis basis, Vector items)
        {
            var newBasis = new Basis();
            for (int i = 0; i < items.cols - 1; i++)
            {
                if (items[i] == 0)
                    newBasis.Add(basis[i]);
                else
                {
                    bool sign = items[i] > 0;
                    for (int j = i + 1; j < items.cols; j++)
                    {
                        if (items[j] != 0 && items[j] > 0 ^ sign)
                        {
                            var lcm = MathExtensions.LCM((int)items[i], (int)items[j]);
                            basis.Add((lcm / (int)items[i]) * basis[i] + (lcm / (int)items[j]) * basis[j]);
                        }
                    }
                }
            }
            return newBasis;
        }

    }
}