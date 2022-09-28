using UnityEngine;

namespace II
{
    public class Poop : MonoBehaviour, IDamage
    {
        [SerializeField] private Sprite[] spritesPerHp;
        [SerializeField] private SpriteRenderer sr;
        [SerializeField] private BoxCollider2D bc;
        [SerializeField] private DregsInstantiator dregsInstantiator;
        [SerializeField] private PickupDropper pickupDropper;

        private int hp = 4;

        void IDamage.Damage(float damage, EDamageType damageType)
        {
            if (hp <= 0) return;

            if (damageType == EDamageType.Bomb) hp = 0;
            if (damageType == EDamageType.Tear) hp -= 1;

            if (Random.Range(0, 3) == 0)
            {
                dregsInstantiator.InstantitateDregs();
            }

            sr.sprite = spritesPerHp[hp];

            if (hp == 0)
            {
                pickupDropper.Drop();
                sr.sortingLayerID = SortingLayer.NameToID("LowerGround");
                Destroy(bc);
            }
        }
    }
}