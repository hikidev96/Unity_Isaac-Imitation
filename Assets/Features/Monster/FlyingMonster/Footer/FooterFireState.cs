using UnityEngine;

namespace II
{
    public class FooterFireState : FooterState
    {
        public override void Enter()
        {
            base.Enter();

            var fireAnimationState = footer.PlayFireAnimation();
            fireAnimationState.Events.OnEnd += () => footer.ToIdleState();
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
