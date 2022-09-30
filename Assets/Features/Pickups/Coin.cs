using UnityEngine;

namespace II
{
    public class Coin : Pickup
    {
        public override void Pickuped()
        {
            base.Pickuped();

            Isaac.Instance.AddCoin(1);
        }
    }
}
