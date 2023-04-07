using System.Collections.Generic;
using System.Linq;

namespace AirlineSchedule.Logic.DijkstraAlgorithm
{
    public class GraphNeighbourList<T> : Graph<T>
    {
        List<T> contents;
        List<List<Edge>> neighbours;

        public GraphNeighbourList()
        {
            this.contents = new List<T>();
            this.neighbours = new List<List<Edge>>();
        }

        protected override int NodeSum
        {
            get
            {
                return contents.Count();
            }
        }

        public override void NewEdge(T from, T to, double weight)
        {
            int index = contents.IndexOf(from);
            neighbours[index].Add(new Edge()
            {
                to = to,
                weight = weight
            });
        }

        public override void NewNood(T content)
        {
            contents.Add(content);
            neighbours.Add(new List<Edge>());
        }

        protected override T IndexedNode(int index)
        {
            return contents[index];
        }

        protected override List<Edge> Neighbours(T node)
        {
            int index = contents.IndexOf(node);
            return neighbours[index];
        }

        protected override int NodedIndex(T node)
        {
            return contents.IndexOf(node);
        }
    }
}
