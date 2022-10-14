using System.Collections;
using UnityEngine;

namespace II
{
    public class WanderMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private float movementSpeed;

        private Vector2 dir;

        public Vector2 Dir => dir;

        private void Start()
        {
            StartCoroutine(SetDirRegularlly());
        }

        private void FixedUpdate()
        {
            rb2d.AddForce(dir * movementSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }

        private IEnumerator SetDirRegularlly()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
                dir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            }
        }
    }
}