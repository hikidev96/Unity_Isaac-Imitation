using UnityEngine;

namespace II
{
    public class Key : Pickup
    {
        protected override void Pickuped()
        {
            base.Pickuped();

            Isaac.Instance.AddKey(1);
        }
    }
}
