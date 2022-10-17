using UnityEngine;

namespace II
{
    public class FrowningGaperChaseState : FrowningGaperState
    {
        [SerializeField] private IsaacChaser chaser;
        [SerializeField] private Sprite headSpriteWhenCloseToIsaac;

        private bool isCloseToIsaac;

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (chaser.Dir.x > chaser.Dir.y)
            {
                frowningGaper.PlayHorizontalWanderAnimation();
            }
            else
            {
                frowningGaper.PlayVerticalWanderAnimation();
            }

            chaser.Chase();

            if (isCloseToIsaac == false && IsCloseToIsaac() == true)
            {
                isCloseToIsaac = true;
                chaser.SetChasingSpeed(15.0f);
                frowningGaper.SetHeadSprite(headSpriteWhenCloseToIsaac);
            }
        }

        public override void PhyiscsUpdate()
        {
            base.PhyiscsUpdate();
        }

        private bool IsCloseToIsaac()
        {
            return Vector2.Distance(chaser.transform.position, Isaac.Instance.transform.position) < 4.0f;
        }
    }
}
