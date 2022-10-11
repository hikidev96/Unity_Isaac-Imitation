using UnityEngine;
using Animancer;

namespace II
{
    public class Fly : FlyingMonster
    {
        [SerializeField] private FlyingMovement flyingMovement;
        [SerializeField] private AnimationClip flyAnimation;

        private void FixedUpdate()
        {
            flyingMovement.Fly();                   
        }

        public AnimancerState PlayFlyAnimation()
        {
            return animancer.Play(flyAnimation);
        }
    }
}
