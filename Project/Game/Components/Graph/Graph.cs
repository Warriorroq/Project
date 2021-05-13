using System.Collections.Generic;
using SFML.System;
namespace Project.Game.Components.Graph
{
    public class Graph
    {
        public List<GraphVertex> Vertices { get; }
        public Graph()
        {
            Vertices = new List<GraphVertex>();
        }
        public void AddVertex(int id, Vector2f position)
        {
            Vertices.Add(new GraphVertex(id, position));
        }
        public GraphVertex FindVertex(int id)
        {
            foreach (var v in Vertices)
            {
                if (v.Id.Equals(id))
                {
                    return v;
                }
            }

            return null;
        }
        public void AddEdge(int firstName, int secondName)
        {
            var v1 = FindVertex(firstName);
            var v2 = FindVertex(secondName);
            if (v2 != null && v1 != null)
            {
                v1.AddEdge(v2);
                v2.AddEdge(v1);
            }
        }
    }
}
