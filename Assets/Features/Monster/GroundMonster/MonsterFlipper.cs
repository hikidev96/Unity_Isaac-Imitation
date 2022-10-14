using UnityEngine;

namespace II
{
    public class MonsterFlipper : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private Transform view;

        private void Update()
        {
            if (rb2d.velocity.x > 0.0f)
            {
                view.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            else
            {
                view.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }
        }
    }
}
