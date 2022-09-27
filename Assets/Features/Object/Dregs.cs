using UnityEngine;

namespace II
{
    public class Dregs : MonoBehaviour
    {
        [SerializeField] private FakeHeight fakeHeight;

        private void Start()
        {
            fakeHeight.Jump(3.5f, 1.5f);
        }
    }
}
