using System.Collections.Generic;
using Microsoft.Msagl.Drawing;

namespace AdventureWorksVisualizer
{
    public class EntityGraphBuilder
    {
        public void BuildGraph(Graph graph, List<string> tables, List<EntityRelation> relations)
        {
            foreach (var table in tables)
            {
                var node = graph.AddNode(table);
                node.Attr.Shape = Shape.Box;
                node.Attr.FillColor = Color.LightBlue;
            }

            foreach (var relation in relations)
            {
                var edge = graph.AddEdge(relation.FromTable, relation.RelationName, relation.ToTable);
                edge.Attr.ArrowheadAtTarget = ArrowStyle.Normal;
                edge.Attr.LineWidth = 1;
                edge.LabelText = relation.RelationName;
            }
        }
    }
}
