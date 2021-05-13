using System;
using System.Collections.Generic;
using SFML.System;
namespace Project.Game.Components.Graph
{
    public class GraphVertex
    {
        public int Id { get; }
        public List<GraphEdge> Edges { get; }
        public Vector2f position;
        public GraphVertex(int id, Vector2f position)
        {
            Id = id;
            this.position = position;
            Edges = new List<GraphEdge>();
        }
        public void AddEdge(GraphEdge newEdge)
        {
            Edges.Add(newEdge);
        }
        public void AddEdge(GraphVertex vertex)
        {
            var lenght = position.Distance(vertex.position);
            AddEdge(new GraphEdge(vertex, lenght));
        }
        
        public override string ToString() => $"id:{Id}, {position} \n";
    }
}
