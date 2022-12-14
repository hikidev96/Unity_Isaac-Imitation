using UnityEngine;

namespace II
{
    public class FooterFireState : FooterState
    {
        [SerializeField] private TearShooter tearShooter;

        public override void Enter()
        {
            base.Enter();

            var fireAnimationState = footer.PlayFireAnimation();
            fireAnimationState.Events.OnEnd += () => footer.ToIdleState();
            fireAnimationState.Events.Add(0.45f, () => tearShooter.Shoot(Isaac.Instance.transform.position));
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