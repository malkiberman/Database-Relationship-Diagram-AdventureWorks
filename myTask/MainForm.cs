using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;

namespace AdventureWorksVisualizer
{
    public partial class MainForm : Form
    {
        private GViewer viewer;
        private Graph graph;

        public MainForm()
        {
            InitializeComponent();
            InitializeGraph();
        }

        private void InitializeGraph()
        {
            viewer = new GViewer();
            graph = new Graph("AdventureWorks");

            var schemaReader = new DatabaseSchemaReader("Data Source=localhost;Initial Catalog=AdventureWorks2019;Integrated Security=True;");
            var tables = schemaReader.GetTables();
            var relations = schemaReader.GetForeignKeys();

            var graphBuilder = new EntityGraphBuilder();
            graphBuilder.BuildGraph(graph, tables, relations);

            viewer.Graph = graph;
            viewer.Dock = DockStyle.Fill;
            this.Controls.Add(viewer);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
