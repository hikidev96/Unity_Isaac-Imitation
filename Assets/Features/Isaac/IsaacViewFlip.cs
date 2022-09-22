using UnityEngine;

namespace II
{
    public class IsaacViewFlip : MonoBehaviour
    {
        private Vector2 defaultRot = Vector2.zero;
        private Vector2 flipRot = new Vector2(0.0f, 180.0f);

        private void Update()
        {
            if (Manager.Input.MovementValue.x > 0)
            {
                this.transform.localRotation = Quaternion.Euler(defaultRot.x, defaultRot.y, 0.0f);
            }
            else if (Manager.Input.MovementValue.x < 0)
            {
                this.transform.localRotation = Quaternion.Euler(flipRot.x, flipRot.y, 0.0f);
            }
        }
    }
}
