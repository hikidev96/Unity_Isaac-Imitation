using UnityEngine;

namespace II
{
    public class Manager : MonoBehaviour
    {
        public static CameraManager Camera;

        private void Awake()
        {
            Camera = GetComponentInChildren<CameraManager>();
        }
    }
}