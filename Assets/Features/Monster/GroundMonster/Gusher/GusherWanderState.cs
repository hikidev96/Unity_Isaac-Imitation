using System.Collections;
using UnityEngine;

namespace II
{
    public class GusherWanderState : GusherState
    {
        [SerializeField] private WanderMovement wanderMovement;
        [SerializeField] private TearShooter tearShooter;

        private Coroutine shootTearRagularllyCoroutine;

        public override void Enter()
        {
            base.Enter();

            shootTearRagularllyCoroutine = StartCoroutine(ShootTearRagularlly());
        }

        public override void Exit()
        {
            base.Exit();

            StopCoroutine(shootTearRagularllyCoroutine);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (wanderMovement.Dir.x > wanderMovement.Dir.y)
            {
                gusher.PlayHorizontalWanderAnimation();
            }
            else
            {
                gusher.PlayVerticalWanderAnimation();
            }
        }

        public override void PhyiscsUpdate()
        {
            base.PhyiscsUpdate();
        }

        private IEnumerator ShootTearRagularlly()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(2.0f, 3.0f));
                tearShooter.Shoot();
            }
        }
    }
}
