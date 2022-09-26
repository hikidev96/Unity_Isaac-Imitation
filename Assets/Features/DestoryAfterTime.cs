using UnityEngine;

namespace II
{
    public class DestoryAfterTime : MonoBehaviour
    {
        [SerializeField] private float time;

        private void Start()
        {
            Invoke("DestroySelf", time);
        }

        private void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}
