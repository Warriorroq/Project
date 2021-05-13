namespace Project.Game.Components.Graph
{
    public class GraphVertexInfo
    {
        public GraphVertex Vertex { get; set; }
        public bool IsUnvisited { get; set; }
        public float EdgesWeightSum { get; set; }
        public GraphVertex PreviousVertex { get; set; }
        public GraphVertexInfo(GraphVertex vertex)
        {
            Vertex = vertex;
            IsUnvisited = true;
            EdgesWeightSum = float.MaxValue;
            PreviousVertex = null;
        }
    }
}
