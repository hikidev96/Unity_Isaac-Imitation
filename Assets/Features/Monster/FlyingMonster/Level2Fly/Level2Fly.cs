using UnityEngine;
using Animancer;

namespace II
{
    public class Level2Fly : FlyingMonster
    {
        [SerializeField] private IsaacChaser isaacChaser;
        [SerializeField] private Level2FlyIdleState idleState;
        [SerializeField] private Level2FlyDeadState deadState;
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

            isaacChaser.Chase();
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
