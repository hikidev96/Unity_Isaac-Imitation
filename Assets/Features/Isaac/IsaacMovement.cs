using UnityEngine;

namespace II
{
    public class IsaacMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float moveSpeed;        

        public void Move()
        {
            rb.AddForce(Manager.Input.MovementValue * moveSpeed * Time.deltaTime * 4000.0f, ForceMode2D.Force);
        }        
    }
}