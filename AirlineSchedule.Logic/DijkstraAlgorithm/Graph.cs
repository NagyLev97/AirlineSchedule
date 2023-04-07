using System.Collections.Generic;
using System.Linq;

namespace AirlineSchedule.Logic.DijkstraAlgorithm
{
    public abstract class Graph<T>
    {
        protected class Edge
        {
            public T to;
            public double weight;
        }
        public abstract void NewNood(T content);

        public abstract void NewEdge(T from, T to, double weight);

        protected abstract T IndexedNode(int index);

        protected abstract int NodedIndex(T node);

        protected abstract int NodeSum { get; }

        protected abstract List<Edge> Neighbours(T node);

        public List<T> Dijkstra(T start, T goal, ref double sumWeight)
        {
            double[] d = new double[NodeSum];
            T[] n = new T[NodeSum];
            List<T> S = new List<T>();

            for (int i = 0; i < NodeSum; i++)
            {
                T x = IndexedNode(i);
                d[i] = double.PositiveInfinity;
                n[i] = default(T);
                S.Add(x);
            }

            d[NodedIndex(start)] = 0;

            while (S.Count != 0)
            {
                T u = MinTake(S, d);
                foreach (Edge x in Neighbours(u))
                {
                    int index_x = NodedIndex(x.to);
                    int index_u = NodedIndex(u);

                    if (d[index_u] + x.weight < d[index_x])
                    {
                        d[index_x] = d[index_u] + x.weight;
                        n[index_x] = u;
                    }
                }
            }

            //Sum time
            int goalIndex = NodedIndex(goal);
            sumWeight = d[goalIndex];

            //Reached cities
            List<T> cities = new List<T>();

            while (goal != null && !goal.Equals(start))
            {
                cities.Add(goal);
                goal = n[goalIndex];
                goalIndex = NodedIndex(goal);
            }
            cities.Add(start);

            return cities;
        }

        private T MinTake(List<T> S, double[] d)
        {
            int minindex = 0;
            double min = double.PositiveInfinity;

            for (int i = 0; i < S.Count(); i++)
            {
                int idx = NodedIndex(S[i]);
                double weight = d[idx];
                if (weight < min)
                {
                    min = weight;
                    minindex = i;
                }
            }

            T toDelete = S[minindex];
            S.RemoveAt(minindex);

            return toDelete;
        }
    }
}
