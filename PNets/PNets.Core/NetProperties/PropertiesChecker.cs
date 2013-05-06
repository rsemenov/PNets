using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PNets.Core.NetProperties
{
    public class PropertiesChecker
    {
        private PetriNet _petriNet { get; set; }
        private IFindBasisAlgorithm _basisAlgorithm = new TssAlgorithm();

        public List<Vector> Tinvariants { get; private set; }
        public List<Vector> Sinvariants { get; private set; }

        public Boundness? Boundness { get; private set; }
        public Conservativeness? Conservativeness { get; private set; }
        public Consistency? Consistency { get; private set; }
        public Repetitiveness? Repetitiveness { get; private set; }


        public PropertiesChecker(PetriNet petriNet)
        {
            _petriNet = petriNet;
        }

        public void GetTinvariants()
        {
            Tinvariants = _basisAlgorithm.Execute(_petriNet.IncedentMatrix);
        }

        public void GetSinvariants()
        {
            Sinvariants = _basisAlgorithm.Execute(_petriNet.IncedentMatrix.Transpose());
        }

        #region structurall properties

        //A^Tx<=0, x>0
        public Boundness CheckStructurallyBoundness()
        {            
            var incedentTranspose = _petriNet.IncedentMatrix.Transpose();
            var matrix = Matrix.ConcatToRight(incedentTranspose, Matrix.IdentityMatrix(incedentTranspose.rows, incedentTranspose.rows));            

            var basis = _basisAlgorithm.Execute(matrix);

            int[] x = new int[_petriNet.PlacesCount];

            foreach (var v in basis)
            {
                for (int i = 0; i < _petriNet.PlacesCount; i++)
                {
                    if (v[i] > 0)
                        x[i] = 1;
                }
            }

            return x.Length == x.Sum() ? NetProperties.Boundness.StructurallyBounded : NetProperties.Boundness.NotStructurallyBounded;
        }

        //A^Tx=0, x>0
        public Conservativeness CheckConservativeness()
        {
            var cn = new int[_petriNet.PlacesCount];
            var pcn = new int[_petriNet.PlacesCount];

            foreach (var v in Sinvariants)
            {
                for (int i = 0; i < _petriNet.PlacesCount; i++)
                {
                    if (v[i] > 0)
                        cn[i] = 1;
                    if (v[i] >= 0)
                        pcn[i] = 1;
                }
            }

            if (cn.Length == cn.Sum())
                return NetProperties.Conservativeness.Conservative;
            
            if (pcn.Length == pcn.Sum())
                return NetProperties.Conservativeness.PartiallyConservative;

            return NetProperties.Conservativeness.NotConservative;
        }

        //Ax>=0, x>0
        public Repetitiveness CheckRepetitiveness()
        {
            var eMatrix = -1*Matrix.IdentityMatrix(_petriNet.IncedentMatrix.rows, _petriNet.IncedentMatrix.rows);
            var matrix = Matrix.ConcatToRight(_petriNet.IncedentMatrix, eMatrix);

            var basis = _basisAlgorithm.Execute(matrix);

            var rp = new int[_petriNet.IncedentMatrix.cols];
            var prp = new int[_petriNet.IncedentMatrix.cols];
     
            foreach (var v in basis)
            {
                for (int i = 0; i < _petriNet.IncedentMatrix.cols; i++)
                {
                    if (v[i] > 0)
                        rp[i] = 1;
                    if (v[i] >= 0)
                        prp[i] = 1;
                }
            }

            if (rp.Length == rp.Sum())
                return NetProperties.Repetitiveness.Repetitive;

            if (prp.Length == prp.Sum())
                return NetProperties.Repetitiveness.PartiallyRepetitive;

            return NetProperties.Repetitiveness.NotRepetitive;
        }

        //Ax=0, x>0
        public Consistency CheckConsistency()
        {          
            var cn = new int[_petriNet.TransitionsCount];
            var pcn = new int[_petriNet.TransitionsCount];

            foreach (var v in Tinvariants)
            {
                for (int i = 0; i < _petriNet.TransitionsCount; i++)
                {
                    if (v[i] > 0)
                        cn[i] = 1;
                    if (v[i] >= 0)
                        pcn[i] = 1;
                }
            }

            if (cn.Length == cn.Sum())
                return NetProperties.Consistency.Consistent;

            if (pcn.Length == pcn.Sum())
                return NetProperties.Consistency.PartiallyConsistent;

            return NetProperties.Consistency.NotConsistent;
        }

        #endregion
    }
}
