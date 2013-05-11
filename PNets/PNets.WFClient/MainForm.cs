using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Glee.GraphViewerGdi;
using PNets.Core;
using System.IO;
using PNets.Core.NetProperties;
using System.Reflection;
using Microsoft.Glee.Drawing;
using PNets.Core.Trees;
using TreeNode = PNets.Core.Trees.TreeNode;

namespace PNets.WFClient
{
    public partial class MainForm : Form
    {
        private PetriNet _petriNet;
        private PropertiesChecker _propertiesChecker;

        public MainForm()
        {
            InitializeComponent();
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            if(ofd.ShowDialog()==DialogResult.OK)
            {
                if (File.Exists(ofd.FileName))
                {
                    _petriNet = PetriNet.Parse(ofd.FileName);
                }
            }
        }

        private void AnalizeButton_Click(object sender, EventArgs e)
        {
            if(_petriNet!=null)
            {
                ClearAll();
                _propertiesChecker = new PropertiesChecker(_petriNet);
                _propertiesChecker.Analize();
                SetProperties();
                if(_propertiesChecker.CoverageTree!=null)
                {
                    DrawTree(_propertiesChecker.CoverageTree, gViewer1);
                }
                if (_propertiesChecker.FullCoverageTree != null)
                {
                    DrawTree(_propertiesChecker.FullCoverageTree, gViewer2);
                }
            }
        }

        private void ClearAll()
        {
            gViewer1.Graph = new Graph("");
            gViewer2.Graph = new Graph("");
        }

        private void DrawTree(Tree tree, GViewer gViewer)
        {
            var g = new Graph("Coverage tree");
            FillGraph(g, tree.Root);
            gViewer.Graph = g;
        }

        private void FillGraph(Graph g, TreeNode node)
        {
            g.AddNode(node.Id);
            if(node.Child!=null)
            {
                for(int i=0;i<node.Child.Count;i++)
                {
                    FillGraph(g, node.Child[i]);
                    g.AddEdge(node.Id, "t"+node.ChildTransitions[i], node.Child[i].Id);
                }
            }
        }

        private void SetProperties()
        {
            if(_propertiesChecker!=null)
            {
                dataGridView1.Rows.Clear();
                var t = _propertiesChecker.GetType();

                foreach (var propertyInfo in t.GetProperties()
                    .Where(p=>p.GetCustomAttributes(typeof(PropertyAttribute), false).Count()>0))
                {
                    var name = propertyInfo.PropertyType.GetCustomAttributes(typeof (TranslateAttribute), false).FirstOrDefault();
                    if(name!=null)
                    {
                        var value = propertyInfo.GetValue(_propertiesChecker, null);
                        var memInfo = propertyInfo.PropertyType.GetMember(value.ToString());
                        if (memInfo.Length > 0)
                        {
                            var atr = memInfo[0].GetCustomAttributes(typeof (TranslateAttribute), false).FirstOrDefault();
                            if (atr != null)
                            {
                                dataGridView1.Rows.Add(((TranslateAttribute)name).ShowName, ((TranslateAttribute) atr).ShowName);
                            }
                        }
                    }  
                }
            }
        }
    }
}
