using UnityEngine;
using Animancer;

namespace II
{
    public class Fly : FlyingMonster
    {
        [SerializeField] private FlyingMovement flyingMovement;
        [SerializeField] private FlyIdleState idleState;
        [SerializeField] private FlyDeadState deadState;
        [SerializeField] private AnimationClip flyAnimation;
        [SerializeField] private AnimationClip deadAnimation;

        protected override void Awake()
        {
            base.Awake();

            onDie?.AddListener(ToDeadState);
        }

        private void FixedUpdate()
        {
            if (isDead == true)
                return;

            flyingMovement.Fly();
        }

        public AnimancerState PlayIdleAnimation()
        {
            return animancer.Play(flyAnimation);
        }

        public AnimancerState PlayDeadAnimation()
        {
            return animancer.Play(deadAnimation);
        }

        public void ToIdleState()
        {
            sm.ChangeStateTo(idleState);
        }

        public void ToDeadState()
        {
            sm.ChangeStateTo(deadState);
        }
    }
}
