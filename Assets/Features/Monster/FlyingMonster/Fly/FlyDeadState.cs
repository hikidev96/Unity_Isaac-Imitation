using UnityEngine;

namespace II
{
    public class FlyDeadState : FlyState
    {
        public override void Enter()
        {
            base.Enter();

            var deadAnimationState = fly.PlayDeadAnimation();

            deadAnimationState.Events.OnEnd += () => Destroy(fly.gameObject);
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