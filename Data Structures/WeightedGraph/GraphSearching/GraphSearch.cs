using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightedGraphNodes.Interfaces;

namespace WeightedGraphNodes.GraphSearching
{
    class GraphSearch<T>
    {
        public IGraph<T> Graph { get; private set; }

        public GraphSearch(IGraph<T> newGraph)
        {
            Graph = newGraph;
        }

        public bool DoSearch(T SearchData)
        {
            for (int i = 0; i < Graph.Nodes.Count; i++)
            {
                //if (Graph.Nodes[i].Data.Equals(SearchData))
                //{
                //    return true;
                //}

                for (int j = 0; j < Graph.Nodes[i].Next.Count; j++)
                {
                    if (Graph.Nodes[i].Next[j].Data.Equals(SearchData))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
