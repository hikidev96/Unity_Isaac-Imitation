using UnityEngine;

namespace II
{
    public class Manager : MonoBehaviour
    {
        public static CameraManager Camera;
        public static InputManager Input;

        private void Awake()
        {
            Camera = GetComponentInChildren<CameraManager>();
            Input = GetComponentInChildren<InputManager>(); 
        }
    }
}