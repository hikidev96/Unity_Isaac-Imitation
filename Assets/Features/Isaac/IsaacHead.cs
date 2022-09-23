using UnityEngine;

namespace II
{
    public class IsaacHead : MonoBehaviour
    {
        [SerializeField] private Animator headAnimator;

        private Vector2 defaultRot = Vector2.zero;
        private Vector2 flipRot = new Vector2(0.0f, 180.0f);

        private void Update()
        {
            if (Manager.Input.FireValue == Vector2.zero)
            {
                PlayHeadAnimationByMovementInput();
                FlipByMovementValue();
            }
            else
            {
                PlayHeadAnimationByFireInput();
                FlipByFireValue();
            }
        }

        private void PlayHeadAnimationByMovementInput()
        {
            if (Manager.Input.MovementValue.x != 0.0f)
            {
                headAnimator.Play("Horizontal");
            }
            else if (Manager.Input.MovementValue.y <= 0)
            {
                headAnimator.Play("Front");
            }
            else if (Manager.Input.MovementValue.y > 0)
            {
                headAnimator.Play("Back");
            }
        }

        private void PlayHeadAnimationByFireInput()
        {
            if (Manager.Input.FireValue.x != 0.0f)
            {
                headAnimator.Play("Horizontal");
            }
            else if (Manager.Input.FireValue.y <= 0)
            {
                headAnimator.Play("Front");
            }
            else if (Manager.Input.FireValue.y > 0)
            {
                headAnimator.Play("Back");
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

        private void FlipByFireValue()
        {
            if (Manager.Input.FireValue.x > 0)
            {
                this.transform.localRotation = Quaternion.Euler(defaultRot.x, defaultRot.y, 0.0f);
            }
            else if (Manager.Input.FireValue.x < 0)
            {
                this.transform.localRotation = Quaternion.Euler(flipRot.x, flipRot.y, 0.0f);
            }
        }
    }
}
