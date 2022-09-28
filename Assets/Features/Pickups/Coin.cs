using UnityEngine;

namespace II
{
    public class Coin : Pickup
    {
        protected override void Pickuped()
        {
            base.Pickuped();

            Isaac.Instance.AddCoin(1);
        }
    }
}
