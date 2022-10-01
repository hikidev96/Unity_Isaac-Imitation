using UnityEngine;

namespace II
{
    public class Heart : Pickup
    {
        public override void Pickuped()
        {            
            if (Isaac.Instance.TryRecoverHeart(1))
            {
                StartCoroutine(PlayPickupAnimation());
            }
        }
    }
}
