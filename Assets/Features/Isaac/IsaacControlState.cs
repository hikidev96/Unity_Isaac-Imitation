using UnityEngine;

namespace II
{
    public class IsaacControlState : IsaacState
    {
        [SerializeField] private IsaacBody isaacBody;

        public override void Enter()
        {
            base.Enter();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhyiscsUpdate()
        {
            base.PhyiscsUpdate();

            isaacBody.Move();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}