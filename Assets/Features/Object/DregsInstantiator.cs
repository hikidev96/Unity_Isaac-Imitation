using System.Collections.Generic;
using UnityEngine;

namespace II
{
    public class DregsInstantiator : MonoBehaviour
    {
        [SerializeField] private List<GameObject> dregsPrefabs;
        [SerializeField] private Vector2 dregsRandomCountRange = new Vector2(1, 3);

        public void InstantitateDregs()
        {
            var loopCount = Random.Range(dregsRandomCountRange.x, dregsRandomCountRange.y + 1);

            for (int i = 0; i < loopCount; ++i)
            {
                Instantiate(dregsPrefabs[Random.Range(0, dregsPrefabs.Count)], this.transform.position, Quaternion.identity);
            }
        }
    }
}