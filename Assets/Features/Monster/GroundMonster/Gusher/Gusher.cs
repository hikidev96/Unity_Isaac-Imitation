using UnityEngine;
using Animancer;

namespace II
{
    public class Gusher : GroundMonster
    {
        [SerializeField] private GusherStandState standState;
        [SerializeField] private GusherWanderState wanderState;
        [SerializeField] private AnimationClip horizontalWanderAnimation;
        [SerializeField] private AnimationClip verticalWanderAnimation;
        [SerializeField] private AnimationClip standAnimation;

        public AnimancerState PlayStandAnimation()
        {
            return animancer.Play(standAnimation);
        }

        public AnimancerState PlayHorizontalWanderAnimation()
        {
            return animancer.Play(horizontalWanderAnimation);
        }

        public AnimancerState PlayVerticalWanderAnimation()
        {
            return animancer.Play(verticalWanderAnimation);
        }

        public void ToStandState()
        {
            sm.ChangeStateTo(standState);
        }

        public void ToWanderState()
        {
            sm.ChangeStateTo(wanderState);
        }
    }
}