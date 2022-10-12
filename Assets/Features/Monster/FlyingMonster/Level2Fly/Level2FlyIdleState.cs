using UnityEngine;

namespace II
{
    public class Level2FlyIdleState : Level2FlyState
    {
        public override void Enter()
        {
            base.Enter();

            level2Fly.PlayIdleAnimation();
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
