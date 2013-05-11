using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNets.Core.Trees;

namespace PNets.Core.NetProperties
{
    public class PropertiesChecker
    {
        private PetriNet _petriNet { get; set; }
        private IFindBasisAlgorithm _basisAlgorithm = new TssAlgorithm();
        private CoverageTreeBuilder _coverageTreeBuilder;
        private FullCoverageTreeBuilder _fullCoverageTreeBuilder;

        public List<Vector> Tinvariants { get; private set; }
        public List<Vector> Sinvariants { get; private set; }

        public Tree CoverageTree { get; private set; }
        public Tree FullCoverageTree { get; private set; }

        [Property]
        public StructurallyBoundness StructurallyBoundness { get; private set; }
        [Property]
        public Boundness Boundness { get; private set; }
        [Property]
        public Conservativeness Conservativeness { get; private set; }
        [Property]
        public Consistency Consistency { get; private set; }
        [Property]
        public Repetitiveness Repetitiveness { get; private set; }


        public PropertiesChecker(PetriNet petriNet)
        {
            _petriNet = petriNet;
            _coverageTreeBuilder = new CoverageTreeBuilder(_petriNet);
            _fullCoverageTreeBuilder  = new FullCoverageTreeBuilder(_petriNet);
        }

        public void Analize()
        {
            GetTinvariants();
            GetSinvariants();
            StructurallyBoundness = CheckStructurallyBoundness();
            Conservativeness = CheckConservativeness();
            Consistency = CheckConsistency();
            Repetitiveness = CheckRepetitiveness();

            CoverageTree = _coverageTreeBuilder.Build();

            if (StructurallyBoundness == StructurallyBoundness.NotStructurallyBounded)
            {
                Boundness = CheckBoundness();
                if(Boundness == Boundness.Unbounded)
                {
                    FullCoverageTree = _fullCoverageTreeBuilder.Build();
                }
            }
        }

        public void GetTinvariants()
        {
            Tinvariants = _basisAlgorithm.Execute(_petriNet.IncedentMatrix);
        }

        public void GetSinvariants()
        {
            Sinvariants = _basisAlgorithm.Execute(_petriNet.IncedentMatrix.Transpose());
        }

        public Boundness CheckBoundness()
        {
            if(CoverageTree!=null)
            {
                if(CoverageTree.TraverseAnyChecking((node)=>
                                                        {
                                                            for(int i=0;i<node.Marking.rows;i++)
                                                            {
                                                                if(node.Marking[i]==double.PositiveInfinity)
                                                                    return true;
                                                            }
                                                            return false;
                                                        }))
                {
                    return Boundness.Unbounded;
                }
                return Boundness.Bounded;
            }
            return Boundness.Unbounded;
        }

        #region structurall properties

        //A^Tx<=0, x>0
        public StructurallyBoundness CheckStructurallyBoundness()
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

            return x.Length == x.Sum() ? NetProperties.StructurallyBoundness.StructurallyBounded : NetProperties.StructurallyBoundness.NotStructurallyBounded;
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
                return Conservativeness.Conservative;
            
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
