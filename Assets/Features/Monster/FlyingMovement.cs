using UnityEngine;

namespace II
{
    public class FlyingMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private float flyingSpeed = 1.0f;

        public void Fly()
        {
            var dir = GetRandomVector2Dir();
            rb2d.MovePosition(rb2d.position + dir * flyingSpeed * Time.deltaTime);
        }

        private Vector2 GetRandomVector2Dir()
        {
            return new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        }
    }
}