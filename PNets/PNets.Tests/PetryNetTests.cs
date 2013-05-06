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
        [Row("Files\\petri_net_1.txt")]
        [Row("Files\\petri_net_2_fig_6.txt")]
        [Row("Files\\petri_net_3_fig_51_i.txt")]
        [Test]
        public void PetryNetShouldBeParseCorrectly(string inFile)
        {           
             var net = PetriNet.Parse(inFile);
             Assert.IsNotNull(net);
        }
                
    }
}
