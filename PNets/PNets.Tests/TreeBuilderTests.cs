using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using PNets.Core;
using PNets.Core.Trees;

namespace PNets.Tests
{
    [TestFixture]
    public class TreeBuilderTests
    {
        [Test]
        public void CoverageTreeShouldBeBuildCorrectly()
        {
            var petriNet = PetriNet.Parse("Files\\petri_net_741.txt");
            var treeBuilder = new CoverageTreeBuilder(petriNet);
            var tree = treeBuilder.Build();
            Assert.IsTrue(tree.Root.Child.Count == 2);
            Assert.IsTrue(tree.Root.Child[0].Marking[0] == 1);
            Assert.IsTrue(tree.Root.Child[0].Marking[1] == double.PositiveInfinity);
            Assert.IsTrue(tree.Root.Child[0].Child == null);
            Assert.IsTrue(tree.Root.Child[1].Marking[2] == 1);
            Assert.IsTrue(tree.Root.Child[1].Child == null); 
        }

        [Test]
        public void FullCoverageTreeShouldBeBuildCorrectly()
        {
            var petriNet = PetriNet.Parse("Files\\petri_net_741.txt");
            var treeBuilder = new FullCoverageTreeBuilder(petriNet);
            var tree = treeBuilder.Build();
            Assert.IsTrue(tree.Root.Child.Count == 2);
            Assert.IsTrue(tree.Root.Child[0].Child.Count == 2);
            Assert.IsTrue(tree.Root.Child[1].Child == null);
            Assert.IsTrue(tree.Root.Child[0].Child[0].Child == null);
            Assert.IsTrue(tree.Root.Child[0].Child[1].Child.Count == 1);
        }

        [Test]
        [Row("Files\\petri_net_2_fig_6.txt")]
        [Row("Files\\petri_net_3_fig_51_i.txt")]
        [Row("Files\\petri_net_4_fig_51_j.txt")]
        [Row("Files\\petri_net_1.txt")]
        public void FullCoverageTreeShouldBeBuild(string file)
        {
            var petriNet = PetriNet.Parse(file);
            var treeBuilder = new FullCoverageTreeBuilder(petriNet);
            var tree = treeBuilder.Build();
            /*Assert.IsTrue(tree.Root.Child.Count == 2);
            Assert.IsTrue(tree.Root.Child[0].Child.Count == 2);
            Assert.IsTrue(tree.Root.Child[1].Child == null);
            Assert.IsTrue(tree.Root.Child[0].Child[0].Child == null);
            Assert.IsTrue(tree.Root.Child[0].Child[1].Child.Count == 1);*/
        }

    }
}
