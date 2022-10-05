using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Yemin.PathFinding
{
    public class Tester : MonoBehaviour
    {
        [SerializeField] private PathFinding pathFinding;
        [SerializeField] private float moveSpeed = 1.0f;
        [SerializeField] private Transform destTrans;

        private List<Node> path;

        private void Update()
        {
            path = pathFinding.FindPath(this.transform.position, destTrans.position);

            if (path == null || path.Count == 1 || Vector2.Distance(this.transform.position, destTrans.position) < 0.1f) return;

            var nextPos = new Vector2(path[1].X, path[1].Y) + new Vector2(pathFinding.transform.position.x, pathFinding.transform.position.y);
            this.transform.Translate((nextPos - new Vector2(this.transform.position.x, this.transform.position.y)).normalized * Time.deltaTime * moveSpeed, Space.World);
        }
    }
}