using Project.Game.Components.Graph;
using System.Collections.Generic;
using SFML.System;
namespace Project.Game
{
    public class ComponentNavAgent : Component
    {
        public List<GraphVertex> path;
        private Dijkstra PathFinder;
        public ComponentNavAgent(GameObject parent) : base(parent)
        {
            path = new();
            PathFinder = new Dijkstra(GraphMaps.graph1);
        }
        public Vector2f GetNextPoint()
        {
            var Vertex = path[0];
            path.Remove(Vertex);
            return Vertex.position;
        }
        public void FindPath(Vector2f destination)
        {
            path = new();
            var a = PathFinder.FindNearestVertex(owner.position);
            var b = PathFinder.FindNearestVertex(destination);
            path = PathFinder.FindShortestPath(a.Id, b.Id);
            path.Reverse();
            path.Add(new GraphVertex(int.MaxValue, destination));
        }
    }
}
