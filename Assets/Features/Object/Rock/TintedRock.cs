using UnityEngine;

namespace II
{
    public class TintedRock : Rock
    {
        [SerializeField] private PickupDropper pickupDropper;

        protected override void DestroySelf()
        {
            dregsInstantiator.InstantitateDregs();
            pickupDropper.Drop();
            Destroy(this.gameObject);
        }
    }
}