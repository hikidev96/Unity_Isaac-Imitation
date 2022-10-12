using UnityEngine;

namespace II
{
    public class FooterIdleState : FooterState
    {
        public override void Enter()
        {
            base.Enter();

            footer.PlayIdleAnimation();
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
