using UnityEngine;

namespace II
{
    public class FlyIdleState : FlyState
    {
        public override void Enter()
        {
            base.Enter();

            fly.PlayIdleAnimation();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhyiscsUpdate()
        {
            base.PhyiscsUpdate();
        }
    }
}
