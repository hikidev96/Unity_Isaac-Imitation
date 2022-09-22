using UnityEngine;

namespace II
{
    public class IsaacControlState : IsaacState
    {
        [SerializeField] private Animator headAnimator;
        [SerializeField] private Animator bodyAnimator;
        [SerializeField] private IsaacMovement isaacMovement;

        public override void Enter()
        {
            base.Enter();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhyiscsUpdate()
        {
            base.PhyiscsUpdate();

            isaacMovement.Move();

            PlayHeadAnimation();
            PlayBodyAnimation();
        }

        public override void Exit()
        {
            base.Exit();
        }

        private void PlayHeadAnimation()
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

        private void PlayBodyAnimation()
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
    }
}