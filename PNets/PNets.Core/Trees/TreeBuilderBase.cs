using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNets.Core.Trees;

namespace PNets.Core
{
    public abstract class TreeBuilderBase
    {
        protected PetriNet PetriNet;

        public TreeBuilderBase(PetriNet petriNet)
        {
            PetriNet = petriNet;
        }

        public abstract Tree Build(Vector initialMarking = null);

        protected virtual BackTrackCheckingResult BackTrackChecking(TreeNode node)
        {
            //backtrack
            var trackNode = node.Parent;
            List<int> omegaPlaces;
            while (trackNode != null)
            {
                bool nodesEqual = true;
                bool less = true;
                omegaPlaces = new List<int>();
                for (int p = 0; p < PetriNet.PlacesCount; p++)
                {
                    if (trackNode.Marking[p] != node.Marking[p])
                        nodesEqual = false;
                    if (trackNode.Marking[p] > node.Marking[p])
                        less = false;
                    if (less && trackNode.Marking[p] < node.Marking[p])
                    {
                        omegaPlaces.Add(p);
                        //break; //todo fix here
                    }
                }
                if (nodesEqual) // node is equal to some parent, marking as leaf
                    return BackTrackCheckingResult.NodeIsEqualToParent;

                if (less && omegaPlaces.Count > 0) // some parent[p] < node[p] marking as omega leaf
                {
                    for (int i = 0; i < omegaPlaces.Count; i++)
                        node.Marking[omegaPlaces[i]] = double.PositiveInfinity;
                    return BackTrackCheckingResult.NodeIsOmegaLeaf;
                }
                trackNode = trackNode.Parent;
            }
            return BackTrackCheckingResult.Nothing;
        }

        protected virtual List<int> GetAvailableTransitions(TreeNode node)
        {
            List<int> tSet = new List<int>();
            for (int i = 0; i < node.Marking.rows; i++)
            {
                if (node.Marking[i] > 0)
                {
                    tSet = tSet.Union(GetPostPSet(i, (int)node.Marking[i])).ToList();
                }
            }

            List<int> tRes = new List<int>();
            for (int i = 0; i < tSet.Count; i++)
            {
                bool toAdd = true;
                for (int p = 0; p < PetriNet.PlacesCount; p++)
                {
                    if (PetriNet.WeightMatrix[p, tSet[i]] != null && 
                        PetriNet.WeightMatrix[p, tSet[i]].PT > 0 && PetriNet.WeightMatrix[p, tSet[i]].PT > node.Marking[p])
                    {
                        toAdd = false;
                    }
                }
                if (toAdd)
                    tRes.Add(tSet[i]);
            }
            return tRes;
        }

        private List<int> GetPostPSet(int p, int mp)
        {
            var postPSet = new List<int>();
            for (int t = 0; t < PetriNet.TransitionsCount; t++)
            {
                if (PetriNet.WeightMatrix[p, t] != null && PetriNet.WeightMatrix[p, t].PT > 0 && PetriNet.WeightMatrix[p, t].PT <= mp)
                    postPSet.Add(t);
            }
            return postPSet;
        }        
    }
}
