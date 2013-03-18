using System.IO;
using System;
using System.Linq;

namespace PNets.Core
{
    public class PetriNet
    {
        public int PlacesCount { get; set; }
        public int TransitionsCount { get; set; }
        public WeightElement[,] WeightMatrix { get; set; }
        public Vector InitialMarking { get; set; }        

        public Matrix IncedentMatrix { get; set; }

        public static PetriNet Parse(string file)
        {
            string[] lines = File.ReadAllLines(file);
            
            var net = new PetriNet();            
            net.PlacesCount = int.Parse(lines[0]);
            net.TransitionsCount = int.Parse(lines[1]);
            net.WeightMatrix = new WeightElement[net.PlacesCount, net.TransitionsCount];

            int k = int.Parse(lines[2]);
            for (int i = 3; i < k+3; i++)
            {
                var parts = lines[i].Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
                
                if (parts.Length != 3)
                {
                    throw new FormatException(string.Format("Incorrect file format. Arcs arguments are not correct. Line = ", k));
                }

                var arcType = (ArcType)Enum.Parse(typeof(ArcType), (parts[0][0].ToString()+parts[1][0].ToString()).ToUpperInvariant());
                int p = int.Parse(parts[arcType == ArcType.PT ? 0 : 1].Substring(1));
                int t = int.Parse(parts[arcType == ArcType.PT ? 1 : 0].Substring(1));
                
                if (net.WeightMatrix[p, t] == null)
                    net.WeightMatrix[p, t] = new WeightElement();

                if (arcType == ArcType.PT)
                    net.WeightMatrix[p, t].PT = int.Parse(parts[2]);
                else
                    net.WeightMatrix[p, t].TP = int.Parse(parts[2]);
            }

            net.InitialMarking = new Vector(net.PlacesCount);
            var m0 = lines[k+3].Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < m0.Length; i++)
            {
                net.InitialMarking[i] = int.Parse(m0[i]);
            }

            return net;
        }

        private void BuildIncedentMatrix()
        {
            IncedentMatrix = new Matrix(PlacesCount, TransitionsCount);
            
            for (int p = 0; p < PlacesCount; p++)
            {
                for (int t = 0; t < TransitionsCount; t++)
                {
                    if(WeightMatrix[p,t]!=null)
                        IncedentMatrix[p, t] = WeightMatrix[p, t].TP - WeightMatrix[p, t].PT;
                }
            }
        }

        public bool IsStructuralBounded()
        {            
            BuildIncedentMatrix();
            var incedentTranspose = IncedentMatrix.Transpose();
            var matrix = Matrix.ConcatToRight(incedentTranspose, Matrix.IdentityMatrix(incedentTranspose.rows, incedentTranspose.rows));
            IFindBasisAlgorithm basisAlgorithm = new TssAlgorithm();

            var basis = basisAlgorithm.Execute(matrix);
            int[] y = new int[PlacesCount];
            
            foreach (var v in basis)
            {
                for (int i = 0; i < PlacesCount; i++)
                {
                    if (v[i] > 0)
                        y[i] = 1;
                }
            }
            
            return y.Sum()==y.Length;
        }


    }

    public class WeightElement
    {
        public WeightElement()
        {        }

        public WeightElement(int pt, int tp)
        {
            PT = pt;
            TP = tp;
        }

        public int PT { get; set; }
        public int TP { get; set; }
    }

    public enum ArcType
    {
        PT,
        TP
    }
}