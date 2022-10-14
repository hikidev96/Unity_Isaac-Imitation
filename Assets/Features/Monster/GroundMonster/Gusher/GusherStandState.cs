using UnityEngine;

namespace II
{
    public class GusherStandState : GusherState
    {
        public override void Enter()
        {
            base.Enter();

            gusher.PlayStandAnimation();
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
            gusher.ToWanderState();
        }
    }
}
