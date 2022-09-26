using System.Collections.Generic;
using UnityEngine;

namespace II
{
    public enum ERoomContentSize
    {
        OneByOne,
    }

    [System.Serializable]
    public class RoomObjectGeneration
    {
        [SerializeField] private GameObject prefab;
        [SerializeField, Range(0.0f, 100.0f)] private float chance;

        public GameObject Prefab => prefab;
        public float Chance => chance;
    }

    public class RoomObjectSpot : MonoBehaviour
    {
        [SerializeField] private List<RoomObjectGeneration> roomObjectGenerations;
        [SerializeField] private ERoomContentSize roomObjectSize;

        private void Awake()
        {
            InstantiateObject();
        }

        public void InstantiateObject()
        {
            for (int i = 0; i < roomObjectGenerations.Count; ++i)
            {
                if (roomObjectGenerations[i].Chance >= Random.Range(0.0f, 100.0f))
                {
                    Instantiate(roomObjectGenerations[Random.Range(0, roomObjectGenerations.Count)].Prefab, this.transform.position, Quaternion.identity);
                    return;
                }
            }

            Instantiate(roomObjectGenerations[0].Prefab, this.transform.position, Quaternion.identity);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            switch (roomObjectSize)
            {
                case ERoomContentSize.OneByOne:
                    Gizmos.DrawWireCube(this.transform.position, new Vector2(1.0f, 1.0f));
                    break;
                default:
                    LogHelper.ShowDefaultCaseLog();
                    break;
            }
        }
    }
}