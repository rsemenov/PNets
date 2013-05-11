using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PNets.Core.Trees
{
    public class TreeNode
    {
        public Vector Marking { get; set; }
        public List<TreeNode> Child { get; set; }
        public List<int> ChildTransitions { get; set; }
        public TreeNode Parent { get; set; }

        private string _id;
        public string Id
        {
            get
            {
                if (String.IsNullOrEmpty(_id))
                {
                    _id = "[";
                    for (int i = 0; i < Marking.rows; i++)
                    {
                        _id += (Marking[i] == double.PositiveInfinity ? "w" : Marking[i].ToString()) + ";";
                    }
                    _id = Id.TrimEnd(';') + "]";
                }
                return _id;
            }
        }


        public bool IsOmegaLeaf
        {
            get
            {
                if (Child != null && Child.Count>0)
                    return false;
                for (int i=0; i < Marking.rows; i++)
                {
                    if (Marking[i] == double.PositiveInfinity)
                        return true;
                }
                return false;
            }
        }

        public TreeNode(Vector marking)
        {
            this.Marking = marking;
        }
        
        public void AddChild(TreeNode node, int transition)
        {
            if (Child == null)
                Child = new List<TreeNode>();
            if (ChildTransitions == null)
                ChildTransitions = new List<int>();
            node.Parent = this;
            Child.Add(node);
            ChildTransitions.Add(transition);
        }
    }

    public class Tree
    {
        public TreeNode Root { get; set; }

        public bool TraverseAnyChecking(Func<TreeNode, bool> predicate)
        {
            return TraverseAnyChecking(predicate, Root);
        }

        private bool TraverseAnyChecking(Func<TreeNode, bool> predicate, TreeNode node)
        {
            if (predicate(node))
                return true;

            return node.Child != null && node.Child.Any(child => TraverseAnyChecking(predicate, child));
        }
    }

   
}
