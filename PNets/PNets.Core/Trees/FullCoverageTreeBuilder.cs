using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PNets.Core.Trees
{
    //TODO build this using existing coverageTree. Do not build twice!
    public class FullCoverageTreeBuilder : TreeBuilderBase
    {
        public FullCoverageTreeBuilder(PetriNet petriNet)
            : base(petriNet)
        {
        }

        public override Tree Build(Vector initialMarking = null)
        {
            PetriNet.BuildIncedentMatrix();
            var tree = new Tree();
            tree.Root = new TreeNode(initialMarking ?? PetriNet.InitialMarking);
            BuildFromNode(tree.Root);
            Trace(tree.Root);
            return tree;
        }

        private void Trace(TreeNode node)
        {
            if (node.IsOmegaLeaf)
            {
                var newNode = new TreeNode(node.Marking);
                BuildFromNode(newNode);
                node.Child = newNode.Child;
                node.Marking = newNode.Marking;
                node.ChildTransitions = newNode.ChildTransitions;
                return;
            }
            if(node.Child!=null)
                foreach (var child in node.Child)
                    Trace(child);
        }

        private void BuildFromNode(TreeNode node)
        {
            var tSet = GetAvailableTransitions(node);
            if (tSet != null && tSet.Count > 0)
            {
                switch (BackTrackChecking(node))
                {
                    case BackTrackCheckingResult.NodeIsEqualToParent:
                    case BackTrackCheckingResult.NodeIsOmegaLeaf:
                        return;
                    case BackTrackCheckingResult.Nothing:
                        break;
                }

                //building child nodes
                foreach (var t in tSet)
                {
                    var newMarking = new Vector(PetriNet.PlacesCount);
                    for (int p = 0; p < PetriNet.PlacesCount; p++)
                    {
                        newMarking[p] = node.Marking[p] + PetriNet.IncedentMatrix[p, t];
                    }
                    node.AddChild(new TreeNode(newMarking), t);
                }
                foreach (var childNode in node.Child)
                {
                    BuildFromNode(childNode);
                }
            }
        }


    }
}
