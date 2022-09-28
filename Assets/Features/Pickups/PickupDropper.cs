using UnityEngine;

namespace II
{
    public class PickupDropper : MonoBehaviour
    {
        [SerializeField] private GameObject[] pickupPrefabs;
        [SerializeField] private int dropCount;

        public void Drop()
        {
            for (int i = 0; i < dropCount; ++i)
            {
                Instantiate(pickupPrefabs[Random.Range(0, pickupPrefabs.Length)], this.transform.position, Quaternion.identity);  
            }
        }
    }
}
