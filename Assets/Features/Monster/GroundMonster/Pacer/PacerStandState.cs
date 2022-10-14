using UnityEngine;

namespace II
{
    public class PacerStandState : PacerState
    {
        public override void Enter()
        {
            base.Enter();

            pacer.PlayStandAnimation();
            Invoke("ToWanderState", 1.0f);
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

        private void ToWanderState()
        {
            pacer.ToWanderState();
        }
    }
}
