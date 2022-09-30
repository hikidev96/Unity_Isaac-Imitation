using UnityEngine;

namespace II
{
    public class Key : Pickup
    {
        public override void Pickuped()
        {
            base.Pickuped();

            Isaac.Instance.AddKey(1);
        }
    }
}
