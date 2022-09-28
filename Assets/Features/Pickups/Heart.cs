using UnityEngine;

namespace II
{
    public class Heart : Pickup
    {
        protected override void Pickuped()
        {            
            if (Isaac.Instance.TryAddHeart(1))
            {
                StartCoroutine(PlayPickupAnimation());
            }
        }
    }
}
