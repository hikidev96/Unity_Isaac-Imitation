using UnityEngine;
using Animancer;

namespace II
{
    public class FrowningGaper : GroundMonster
    {
        [SerializeField] private AnimationClip horizontalWanderAnimation;
        [SerializeField] private AnimationClip verticalWanderAnimation;
        [SerializeField] private SpriteRenderer headSR;
        [SerializeField] private GameObject pacerPrefab;
        [SerializeField] private GameObject gusherPrefab;

        protected override void Awake()
        {
            base.Awake();

            onDie.AddListener(() =>
            {
                var randomValue = Random.Range(0, 2);

                if (randomValue == 1)
                {
                    Monster.Create(pacerPrefab, this.transform.position, room);
                }
                else
                {
                    Monster.Create(gusherPrefab, this.transform.position, room);
                }
            });
        }

        public AnimancerState PlayHorizontalWanderAnimation()
        {
            return animancer.Play(horizontalWanderAnimation);
        }

        public AnimancerState PlayVerticalWanderAnimation()
        {
            return animancer.Play(verticalWanderAnimation);
        }

        public void SetHeadSprite(Sprite headSprite)
        {
            headSR.sprite = headSprite;
        }
    }
}