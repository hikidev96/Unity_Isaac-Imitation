using UnityEngine;

namespace II
{
    public class IsaacChaser : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private float chasingSpeed;

        public Vector2 Dir => rb2d.velocity.normalized;

        public void Chase()
        {
            rb2d.AddForce(GetDirTowardIsaac() * chasingSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }

        public void SetChasingSpeed(float chasingSpeed)
        {
            this.chasingSpeed = chasingSpeed;
        }

        private Vector2 GetDirTowardIsaac()
        {
            if (Isaac.Instance == null) return Vector2.zero;

            return (Vector2)(Isaac.Instance.transform.position - this.transform.position).normalized;
        }
    }
}
