using UnityEngine;
using Animancer;

namespace II
{
    public class IsaacTear : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private AnimancerComponent animancer;
        [SerializeField] private AnimationClip poofAnimation;

        private void FixedUpdate()
        {            
            rb.MovePosition(rb.position + (Vector2)rb.transform.right * 7.5f * Time.deltaTime);
        }

        private void Poof()
        {
            animancer.Play(poofAnimation).Events.OnEnd += () =>
            {
                Destroy(this.gameObject);
            };
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                Poof();
            }
        }
    }
}