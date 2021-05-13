namespace Project.Game.Components.Graph
{
    public class GraphEdge
    {
        public GraphVertex ConnectedVertex { get; }
        public float EdgeWeight { get; }
        public GraphEdge(GraphVertex connectedVertex, float weight)
        {
            ConnectedVertex = connectedVertex;
            EdgeWeight = weight;
        }
    }
}
