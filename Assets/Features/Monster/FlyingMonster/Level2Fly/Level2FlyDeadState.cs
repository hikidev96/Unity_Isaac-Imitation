using UnityEngine;

namespace II
{
    public class Level2FlyDeadState : Level2FlyState
    {
        public override void Enter()
        {
            base.Enter();

            var deadAnimationState = level2Fly.PlayDeadAnimation();

            deadAnimationState.Events.OnEnd += () => Destroy(level2Fly.gameObject);
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
