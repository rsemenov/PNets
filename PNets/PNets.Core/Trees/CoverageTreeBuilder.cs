using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNets.Core.Trees;

namespace PNets.Core
{
    public class CoverageTreeBuilder: TreeBuilderBase
    {
        public CoverageTreeBuilder(PetriNet petriNet):base(petriNet)
        {                
        }

        public override Tree Build(Vector initialMarking=null)
        {
            PetriNet.BuildIncedentMatrix();
            var tree = new Tree();
            tree.Root = new TreeNode(initialMarking ?? PetriNet.InitialMarking);
            BuildFromNode(tree.Root);
            return tree;
        }

        private void BuildFromNode(TreeNode node)
        {
            var tSet = GetAvailableTransitions(node);
            if (tSet != null && tSet.Count>0)
            {
                if (BackTrackChecking(node)!=BackTrackCheckingResult.Nothing)
                    return;

                //building child nodes
                foreach (var t in tSet)
                {
                    var newMarking = new Vector(PetriNet.PlacesCount);
                    for (int p = 0; p < PetriNet.PlacesCount; p++)
                    {
                        newMarking[p] = node.Marking[p] + PetriNet.IncedentMatrix[p,t];
                    }
                    node.AddChild(new TreeNode(newMarking),t);
                }
                foreach (var childNode in node.Child)
                {
                    BuildFromNode(childNode);
                }
            }
        }

       
    }

    
}
