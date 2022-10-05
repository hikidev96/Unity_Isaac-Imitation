using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Yemin.PathFinding
{
    public class NormalGrid : MonoBehaviour
    {
        [SerializeField] private int width;
        [SerializeField] private int height;
        [SerializeField] private bool showGrid = true;
        [SerializeField] private bool showIndex = true;

        private float nodeSize = 1;
        private List<List<Node>> grid;

        public int Width => width;
        public int Height => height;
        public float NodeSize => nodeSize;

        public Node this[int y, int x]
        {
            get { return grid[y][x]; }
        }

        public Node GetNode(int x, int y)
        {
            return grid[y][x];
        }

        public void GenerateGrid()
        {
            grid = new List<List<Node>>();

            for (int i = 0; i < height; i++)
            {
                var horizontalNodes = new List<Node>();

                for (int j = 0; j < width; j++)
                {
                    var node = new Node();
                    node.X = j;
                    node.Y = i;

                    horizontalNodes.Add(node);
                }

                grid.Add(horizontalNodes);
            }
        }

        private void OnDrawGizmos()
        {
            if (grid == null)
            {
                GenerateGrid();
            }

            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    if (showGrid == true)
                    {
                        if (grid[i][j].IsWalkable == true)
                        {
                            Gizmos.color = Color.white;
                        }
                        else
                        {
                            Gizmos.color = Color.red;
                        }

                        Gizmos.DrawWireCube(new Vector2(this.transform.position.x, this.transform.position.y) + new Vector2(grid[i][j].X, grid[i][j].Y), new Vector2(nodeSize, nodeSize));
                    }
                    if (showIndex == true)
                    {
                        Handles.Label(new Vector2(this.transform.position.x, this.transform.position.y) + new Vector2(grid[i][j].X, grid[i][j].Y), $"{i},{j}");
                    }
                }
            }
        }
    }
}