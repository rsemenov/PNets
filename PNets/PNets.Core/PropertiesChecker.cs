using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PNets.Core
{
    public class PropertiesChecker
    {
        private PetriNet _petriNet { get; set; }

        public PropertiesChecker(PetriNet petriNet)
        {
            _petriNet = petriNet;
        }

        public bool IsStructuralBounded()
        {            
            var incedentTranspose = _petriNet.IncedentMatrix.Transpose();
            var matrix = Matrix.ConcatToRight(incedentTranspose, Matrix.IdentityMatrix(incedentTranspose.rows, incedentTranspose.rows));
            IFindBasisAlgorithm basisAlgorithm = new TssAlgorithm();

            var basis = basisAlgorithm.Execute(matrix);
            int[] y = new int[_petriNet.PlacesCount];

            foreach (var v in basis)
            {
                for (int i = 0; i < _petriNet.PlacesCount; i++)
                {
                    if (v[i] > 0)
                        y[i] = 1;
                }
            }

            return y.Sum() == y.Length;
        }
    }
}
