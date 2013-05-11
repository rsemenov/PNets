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
                SetInvariants();
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
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            gViewer1.Graph = new Graph("");
            gViewer2.Graph = new Graph("");
        }

        private void DrawTree(Tree tree, GViewer gViewer)
        {
            var g = new Graph("Coverage tree");
            var graphbuilder = new GraphBuilder();
            graphbuilder.FillGraph(g, tree.Root);
            if(g.NodeCount<50)
                gViewer.Graph = g;
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

        private void SetInvariants()
        {
            for (int i = 0; i < _propertiesChecker.Sinvariants.Count; i++)
            {
                var sinvariant = _propertiesChecker.Sinvariants[i];
                listBox1.Items.Add("s"+i+" = "+sinvariant.ToString());
            }
            for (int i = 0; i < _propertiesChecker.Tinvariants.Count; i++)
            {
                var tinvariant = _propertiesChecker.Tinvariants[i];
                listBox2.Items.Add("t" + i + " = " + tinvariant.ToString());
            }
        }
    }
}
