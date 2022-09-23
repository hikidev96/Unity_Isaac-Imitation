using UnityEngine;

namespace II
{
    public class IsaacBody : MonoBehaviour
    {
        [SerializeField] private Animator bodyAnimator;

        private Vector2 defaultRot = Vector2.zero;
        private Vector2 flipRot = new Vector2(0.0f, 180.0f);

        private void Update()
        {
            PlayBodyAnimationByMovementInput();
            FlipByMovementValue();
        }

        private void PlayBodyAnimationByMovementInput()
        {
            if (Manager.Input.MovementValue.x != 0.0f)
            {
                bodyAnimator.Play("Move_Horizontal");
            }
            else if (Manager.Input.MovementValue.y != 0.0f)
            {
                bodyAnimator.Play("Move_Vertical");
            }
            else if (Manager.Input.MovementValue == Vector2.zero)
            {
                bodyAnimator.Play("Stop");
            }
        }

        private void FlipByMovementValue()
        {
            if (Manager.Input.MovementValue.x > 0)
            {
                this.transform.localRotation = Quaternion.Euler(defaultRot.x, defaultRot.y, 0.0f);
            }
            else if (Manager.Input.MovementValue.x < 0)
            {
                this.transform.localRotation = Quaternion.Euler(flipRot.x, flipRot.y, 0.0f);
            }
        }
    }
}
