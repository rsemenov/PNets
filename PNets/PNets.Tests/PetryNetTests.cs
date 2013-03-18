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
        [Test]
        public void PetryNetShouldBeStructuralBounded(string inFile)
        {
            var net = PetriNet.Parse(inFile);
            Assert.IsTrue(net.IsStructuralBounded());
        }
    }
}
