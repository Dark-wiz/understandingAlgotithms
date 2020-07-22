using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms2
{
    public class Path
    {
        public List<string> Nodes { get; set; } = new List<string>();
        
        public void Add(string node)
        {
            Nodes.Add(node);
        }

        public override string ToString()
        {
            return Nodes.ToString(); 
        }
    }
}
