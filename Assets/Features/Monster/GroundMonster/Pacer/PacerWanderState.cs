using UnityEngine;

namespace II
{
    public class PacerWanderState : PacerState
    {
        [SerializeField] private WanderMovement wanderMovement;

        public override void Enter()
        {
            base.Enter();            
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (wanderMovement.Dir.x > wanderMovement.Dir.y)
            {
                pacer.PlayHorizontalWanderAnimation();
            }
            else
            {
                pacer.PlayVerticalWanderAnimation();
            }
        }

        public override void PhyiscsUpdate()
        {
            base.PhyiscsUpdate();
        }
    }
}
