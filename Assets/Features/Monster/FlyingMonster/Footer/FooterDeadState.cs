using UnityEngine;

namespace II
{
    public class FooterDeadState : FooterState
    {
        public override void Enter()
        {
            base.Enter();

            var deadAnimationState = footer.PlayDeadAnimation();

            deadAnimationState.Events.OnEnd += () => Destroy(footer.gameObject);
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
