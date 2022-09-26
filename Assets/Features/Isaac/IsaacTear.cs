using UnityEngine;
using Animancer;

namespace II
{
    public class IsaacTear : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private AnimancerComponent animancer;
        [SerializeField] private AnimationClip poofAnimation;

        private bool isMove = true;

        private void FixedUpdate()
        {
            Move();
        }

        private void Poof()
        {
            StopMove();

            animancer.Play(poofAnimation).Events.OnEnd += () =>
            {
                Destroy(this.gameObject);
            };
        }

        private void Move()
        {
            if (isMove == false) return;

            rb.MovePosition(rb.position + (Vector2)rb.transform.right * 7.5f * Time.deltaTime);
        }

        private void StopMove()
        {
            isMove = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Poof();

            //if (collision.gameObject.CompareTag("Wall"))
            //{
            //    Poof();
            //}
            //else if (collision.gameObject.CompareTag("Rock"))
            //{
            //    Poof();
            //}
        }
    }
}