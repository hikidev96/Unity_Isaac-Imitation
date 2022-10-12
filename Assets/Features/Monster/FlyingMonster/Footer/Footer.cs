using System.Collections;
using UnityEngine;
using Animancer;

namespace II
{
    public class Footer : FlyingMonster
    {
        [SerializeField] private FlyingMovement flyingMovement;
        [SerializeField] private FooterIdleState idleState;
        [SerializeField] private FooterFireState fireState;
        [SerializeField] private FooterDeadState deadState;
        [SerializeField] private AnimationClip flyAnimation;
        [SerializeField] private AnimationClip fireAnimation;
        [SerializeField] private AnimationClip deadAnimation;

        protected override void Awake()
        {
            base.Awake();

            onDie?.AddListener(ToDeadState);
            StartCoroutine(FireRegularly());
        }

        private void FixedUpdate()
        {
            if (isDead == true)
                return;

            flyingMovement.Fly();
        }

        public AnimancerState PlayFireAnimation()
        {
            if (isDead == true) return null;

            return animancer.Play(fireAnimation);
        }

        public AnimancerState PlayIdleAnimation()
        {
            if (isDead == true) return null;

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

        public void ToFireState()
        {
            sm.ChangeStateTo(fireState);
        }

        public void ToDeadState()
        {
            sm.ChangeStateTo(deadState);
        }

        private IEnumerator FireRegularly()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));
                ToFireState();
            }
        }
    }
}
