using UnityEngine;
using Animancer;

namespace II
{
    public class Tear : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] protected Collider2D cd;
        [SerializeField] protected Transform viewTrans;
        [SerializeField] protected Transform shadowTrans;
        [SerializeField] protected AnimancerComponent animancer;
        [SerializeField] protected AnimationClip poofAnimation;

        private bool isMoving = true;
        private float movingSpeed = 6.0f;
        private float fallAfterTime = 2.0f;
        private float fallingSpeed = 1.0f;
        private bool isFalling = false;

        private void Update()
        {
            if (isMoving == false) return;

            CountFallAfterTime();
            Fall();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void SetTearMovingSpeed(float movingSpeed)
        {
            this.movingSpeed = movingSpeed;
        }

        private void Move()
        {
            if (isMoving == false) return;

            rb.MovePosition(rb.position + (Vector2)rb.transform.right * movingSpeed * Time.deltaTime);
        }

        private void Fall()
        {
            if (isFalling == false) return;

            viewTrans.transform.Translate(Vector2.down * fallingSpeed * Time.deltaTime, Space.Self);

            if (viewTrans.transform.position.y <= shadowTrans.transform.position.y)
            {
                Poof();
            }
        }        

        private void StopMove()
        {
            isMoving = false;
        }

        private void CountFallAfterTime()
        {
            if (isFalling == true) return;

            fallAfterTime -= Time.deltaTime;

            if (fallAfterTime <= 0.0f)
            {
                isFalling = true;
            }
        }

        private void Poof()
        {
            StopMove();
            shadowTrans.gameObject.SetActive(false);
            cd.enabled = false;

            animancer.Play(poofAnimation).Events.OnEnd += () =>
            {
                Destroy(this.gameObject);
            };
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Poof();

            var damageInterface = collision.gameObject.GetComponent<IDamage>();

            if (damageInterface != null)
            {
                damageInterface.Damage(1.0f, EDamageType.Tear);
            }
        }
    }
}
