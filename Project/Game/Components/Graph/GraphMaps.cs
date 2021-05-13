using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Game.Components.Graph
{
    public static class GraphMaps
    {
        public static Graph graph1;
        public static void Init()
        {
            CreateGraph1();
        }
        private static void CreateGraph1()
        {
            graph1 = new Graph();

            graph1.AddVertex(0, new Vector2f(0, 0));
            graph1.AddVertex(100, new Vector2f(0, 600));

            //wall
            graph1.AddVertex(1, new Vector2f(300, 300));
            graph1.AddVertex(2, new Vector2f(700, 300));
            graph1.AddVertex(3, new Vector2f(700, 600));
            graph1.AddVertex(4, new Vector2f(300, 600));


            graph1.AddEdge(1, 2);
            graph1.AddEdge(1, 4);
            graph1.AddEdge(2, 3);
            graph1.AddEdge(3, 4);

            //end


            graph1.AddEdge(0, 100);

            graph1.AddEdge(0, 1);
            graph1.AddEdge(0, 2);

            graph1.AddEdge(100, 4);
            graph1.AddEdge(100, 1);
        }
    }
}
