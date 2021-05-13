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
            graph1.AddVertex(1, new Vector2f(Screen.widthWindow, 0));
            graph1.AddVertex(2, new Vector2f(Screen.widthWindow, Screen.widthWindow));

            graph1.AddVertex(5, new Vector2f(100, 400));
            graph1.AddVertex(3, new Vector2f(0, Screen.heightWindow));

            graph1.AddVertex(4, new Vector2f(Screen.widthWindow / 2f, Screen.widthWindow/2f));

            graph1.AddEdge(4, 0);
            graph1.AddEdge(4, 1);
            graph1.AddEdge(4, 2);
            graph1.AddEdge(4, 3);
            graph1.AddEdge(0, 1);
            graph1.AddEdge(5, 3);
            graph1.AddEdge(0, 5);
            graph1.AddEdge(2, 3);
            graph1.AddEdge(2, 1);
        }
    }
}
