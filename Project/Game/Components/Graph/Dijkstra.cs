using System.Collections.Generic;
using SFML.System;
namespace Project.Game.Components.Graph
{
    public class Dijkstra
    {
        private Graph graph;

        private List<GraphVertexInfo> infos;
        public Dijkstra(Graph graph)
        {
            this.graph = graph;
            InitInfo();
        }
        public GraphVertex FindNearestVertex(Vector2f position)
        {
            var vertex = infos[0].Vertex;
            float lastDistance = float.MaxValue;
            foreach (var graph in infos)
            {
                if(graph.Vertex != vertex)
                {
                    var currentDistance = graph.Vertex.position.Distance(position);
                    if (currentDistance < lastDistance)
                    {
                        vertex = graph.Vertex;
                        lastDistance = currentDistance;
                    }
                }
            }
            return vertex;
        }
        private void InitInfo()
        {
            infos = new List<GraphVertexInfo>();
            foreach (var v in graph.Vertices)
            {
                infos.Add(new GraphVertexInfo(v));
            }
        }
        private GraphVertexInfo GetVertexInfo(GraphVertex v)
        {
            foreach (var i in infos)
            {
                if (i.Vertex.Equals(v))
                {
                    return i;
                }
            }

            return null;
        }
        public GraphVertexInfo FindUnvisitedVertexWithMinSum()
        {
            var minValue = float.MaxValue;
            GraphVertexInfo minVertexInfo = null;
            foreach (var i in infos)
            {
                if (i.IsUnvisited && i.EdgesWeightSum < minValue)
                {
                    minVertexInfo = i;
                    minValue = i.EdgesWeightSum;
                }
            }

            return minVertexInfo;
        }
        public List<GraphVertex> FindShortestPath(int startName, int finishName)
        {
            return FindShortestPath(graph.FindVertex(startName), graph.FindVertex(finishName));
        }
        public List<GraphVertex> FindShortestPath(GraphVertex startVertex, GraphVertex finishVertex)
        {
            InitInfo();
            var first = GetVertexInfo(startVertex);
            first.EdgesWeightSum = 0;
            while (true)
            {
                var current = FindUnvisitedVertexWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextVertex(current);
            }

            return GetPath(startVertex, finishVertex);
        }
        private void SetSumToNextVertex(GraphVertexInfo info)
        {
            info.IsUnvisited = false;
            foreach (var e in info.Vertex.Edges)
            {
                var nextInfo = GetVertexInfo(e.ConnectedVertex);
                var sum = info.EdgesWeightSum + e.EdgeWeight;
                if (sum < nextInfo.EdgesWeightSum)
                {
                    nextInfo.EdgesWeightSum = sum;
                    nextInfo.PreviousVertex = info.Vertex;
                }
            }
        }
        private List<GraphVertex> GetPath(GraphVertex startVertex, GraphVertex endVertex)
        {
            List<GraphVertex> path = new();
            path.Add(endVertex);
            while (startVertex != endVertex)
            {
                endVertex = GetVertexInfo(endVertex).PreviousVertex;
                path.Add(endVertex);
            }

            return path;
        }
    }
}
