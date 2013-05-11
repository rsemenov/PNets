using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Glee.Drawing;
using PNets.Core.Trees;

namespace PNets.WFClient
{
    public class GraphBuilder
    {
        HashSet<string> _edges = new HashSet<string>();

        public void FillGraph(Graph graph, TreeNode node)
        {
            graph.AddNode(node.Id);
            if (node.Child != null)
            {
                for (int i = 0; i < node.Child.Count; i++)
                {
                    FillGraph(graph, node.Child[i]);
                    string edgeId = node.Id + "t" + node.ChildTransitions[i] + node.Child[i].Id;
                    if (!_edges.Contains(edgeId))
                    {
                        _edges.Add(edgeId);
                        graph.AddEdge(node.Id, "t" + node.ChildTransitions[i], node.Child[i].Id);
                    }
                }
            }
        }
    }
}
