using System;
using UnityEngine;

namespace Yemin.PathFinding
{
    public class Node
    {
        public int X = 0;
        public int Y = 0;
        public int GCost = 0;
        public int HCost = 0;
        public int FCost = 0;
        public bool IsWalkable = true;
        public Node ParentNode = null;

        public void Init()
        {
            GCost = int.MaxValue;            
            ParentNode = null;
            CalculateFCost();
        }

        public void CalculateFCost()
        {
            FCost = GCost + HCost;
        }
    }
}