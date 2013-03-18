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
        [Row("-1 1 0 0\r\n1 0 -3 1\r\n-1 1 0 3", "3 3 1 0")]
        [Row("1 -1 0 0 0 0 0\r\n-1 0 1 0 0 0 1\r\n0 0 0 1 -1 0 0\r\n0 0 0 -1 0 1 1\r\n0 1 -1 0 0 0 -1\r\n0 0 0 0 1 -1 -1\r\n0 -1 1 0 -1 1 1",
            "1 1 1 0 0 0 0\r\n0 0 0 1 1 1 0")]
        [Row("1 -1 0 0 0 0 0\r\n-1 0 1 0 0 0 1\r\n0 0 0 1 -1 0 0\r\n0 0 0 -1 0 1 0\r\n0 1 -1 0 0 0 -1\r\n0 0 0 0 1 -1 0\r\n0 -1 1 0 -1 1 1",
            "1 1 1 0 0 0 0\r\n0 0 0 1 1 1 0\r\n1 1 0 0 0 0 1")]
        [Row("1 -1 0 0 0 0 0 1 0 0 0 0 0\r\n0 1 -1 3 0 0 0 0 1 0 0 0 0\r\n-1 0 1 -3 0 0 0 0 0 1 0 0 0\r\n0 0 0 -1 1 0 -1 0 0 0 1 0 0\r\n0 0 0 1 -1 1 0 0 0 0 0 1 0\r\n0 0 0 0 0 -1 1 0 0 0 0 0 1",
            "1 1 1 0 0 0 0 0 0 0 0 0 0\r\n0 0 3 1 1 0 0 0 0 0 0 0 0\r\n0 0 0 0 1 1 1 0 0 0 0 0 0")]
        [Test]
        public void TssAlgorithmShouldWorkCorrect(string matrix, string expectedBasis)
        {
            var initMatrix = Matrix.Parse(matrix);
            var tssAlg = new TssAlgorithm();
            var basis = tssAlg.Execute(initMatrix);
            var expected = Matrix.Parse(expectedBasis);
            Assert.AreEqual(expected.rows, basis.Count);
            for (int r = 0; r < expected.rows; r++)
            {
                var v = expected.GetRow(r);
                Assert.Contains(basis, v);
            }
        }

    }
}
