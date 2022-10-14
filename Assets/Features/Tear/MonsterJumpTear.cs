using UnityEngine;

namespace II
{
    public class MonsterJumpTear : MonsterTear
    {
        [SerializeField] private FakeHeight fakeHeight;

        private void Start()
        {
            fakeHeight.Jump(Random.Range(2.0f, 5.0f), Random.Range(3.0f, 6.0f));
        }

        protected override void Update()
        {
            if (IsFellToGround() == true)
            {
                Poof();
            }
        }

        protected override void FixedUpdate()
        {

        }
    }
}
