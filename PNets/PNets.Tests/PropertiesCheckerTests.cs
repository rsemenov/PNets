using MbUnit.Framework;
using PNets.Core;
using PNets.Core.NetProperties;

namespace PNets.Tests
{
    [TestFixture]
    public class PropertiesCheckerTests
    {
        [Row("Files\\petri_net_1.txt")]
        [Row("Files\\petri_net_2_fig_6.txt")]
        [Row("Files\\petri_net_3_fig_51_i.txt")]
        [Test]
        public void PetryNetShouldBeStructuralBounded(string inFile)
        {
            var net = PetriNet.Parse(inFile);
            var checker = new PropertiesChecker(net);
            Assert.IsTrue(checker.CheckStructurallyBoundness() == Boundness.StructurallyBounded);
        }

        [Row("Files\\petri_net_4_fig_51_j.txt")]
        [Test]
        public void PetryNetShouldBeStructuralUnbounded(string inFile)
        {
            var net = PetriNet.Parse(inFile);
            var checker = new PropertiesChecker(net);
            Assert.IsTrue(checker.CheckStructurallyBoundness() == Boundness.NotStructurallyBounded);
        }

        [Row("Files\\petri_net_4_fig_51_j.txt")]
        [Row("Files\\petri_net_fig_51_f.txt")]
        [Row("Files\\petri_net_fig_51_g.txt")]
        [Test]
        public void PetryNetShouldBeRepetitive(string inFile)
        {
            var net = PetriNet.Parse(inFile);
            var checker = new PropertiesChecker(net);
            Assert.IsTrue(checker.CheckRepetitiveness() == Repetitiveness.Repetitive);
        }

        [Row("Files\\petri_net_3_fig_51_i.txt")]
        [Test]
        public void PetryNetShouldBePartialRepetitive(string inFile)
        {
            var net = PetriNet.Parse(inFile);
            var checker = new PropertiesChecker(net);
            Assert.IsTrue(checker.CheckRepetitiveness() == Repetitiveness.PartiallyRepetitive);
        }

        [Row("Files\\petri_net_fig_51_f.txt")]
        [Test]
        public void PetryNetShouldBeConservative(string inFile)
        {
            var net = PetriNet.Parse(inFile);
            var checker = new PropertiesChecker(net);
            checker.GetSinvariants();
            Assert.IsTrue(checker.CheckConservativeness() == Conservativeness.Conservative);
        }

        [Row("Files\\petri_net_fig_51_g.txt")]
        [Test]
        public void PetryNetShouldBePartialConservative(string inFile)
        {
            var net = PetriNet.Parse(inFile);
            var checker = new PropertiesChecker(net);
            checker.GetSinvariants();
            Assert.IsTrue(checker.CheckConservativeness() == Conservativeness.PartiallyConservative);
        }

        [Row("Files\\petri_net_3_fig_51_i.txt")]
        [Row("Files\\petri_net_4_fig_51_j.txt")]
        [Test]
        public void PetryNetShouldBePartialNotConservative(string inFile)
        {
            var net = PetriNet.Parse(inFile);
            var checker = new PropertiesChecker(net);
            checker.GetSinvariants();
            Assert.IsTrue(checker.CheckConservativeness() == Conservativeness.NotConservative);
        }

        [Row("Files\\petri_net_fig_51_f.txt")]
        [Test]
        public void PetryNetShouldBeConsistent(string inFile)
        {
            var net = PetriNet.Parse(inFile);
            var checker = new PropertiesChecker(net);
            checker.GetTinvariants();
            Assert.IsTrue(checker.CheckConsistency() == Consistency.Consistent);
        }

        [Row("Files\\petri_net_3_fig_51_i.txt")]
        [Row("Files\\petri_net_4_fig_51_j.txt")]
        [Test]
        public void PetryNetShouldBePartialConsistent(string inFile)
        {
            var net = PetriNet.Parse(inFile);
            var checker = new PropertiesChecker(net);
            checker.GetTinvariants();
            Assert.IsTrue(checker.CheckConsistency() == Consistency.PartiallyConsistent);
        }

        [Row("Files\\petri_net_fig_51_g.txt")]
        [Test]
        public void PetryNetShouldBePartialNotConsistent(string inFile)
        {
            var net = PetriNet.Parse(inFile);
            var checker = new PropertiesChecker(net);
            checker.GetTinvariants();
            Assert.IsTrue(checker.CheckConsistency() == Consistency.NotConsistent);
        }
    }
}