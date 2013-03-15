using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using PNets.Core;

namespace PNets.Tests
{
    [TestFixture]
    public class TssAlgorithmTests1
    {
        [Row("-1 1 0 0\r\n1 0 -3 1\r\n0 1 0 3")]
        [Test]
        public void TssAlgorithmShouldWorkCorrect(string matrix)
        {
            var net = new PetriNet();
            net.IncedentMatrix = Matrix.Parse(matrix);
            var tssAlg = new TssAlgorithm();
            var basis = tssAlg.Execute(net);
        }

    }
}
