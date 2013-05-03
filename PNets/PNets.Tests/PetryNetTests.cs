using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using PNets.Core;

namespace PNets.Tests
{
    [TestFixture]
    public class PetriNetTests
    {
        [Row("Files\\petri_net_1.txt")]
        [Test]
        public void PetryNetShouldBeParseCorrectly(string inFile)
        {           
             var net = PetriNet.Parse(inFile);
             Assert.IsNotNull(net);
        }

        [Row("Files\\petri_net_1.txt")]
        [Row("Files\\petri_net_2_fig_6.txt")]
        [Row("Files\\petri_net_3_fig_51_i.txt")]
        [Test]
        public void PetryNetShouldBeStructuralBounded(string inFile)
        {
            var net = PetriNet.Parse(inFile);
            var checker = new PropertiesChecker(net);
            Assert.IsTrue(checker.IsStructuralBounded());
        }

        [Row("Files\\petri_net_4_fig_51_j.txt")]
        [Test]
        public void PetryNetShouldBeStructuralUnbounded(string inFile)
        {
            var net = PetriNet.Parse(inFile);
            var checker = new PropertiesChecker(net);
            Assert.IsFalse(checker.IsStructuralBounded());
        }
    }
}
