using UnityEngine;
using Sirenix.OdinInspector;

namespace II
{
    public class TNT : MonoBehaviour, IDamage
    {
        [SerializeField, TitleGroup("Required"), Required] private SpriteRenderer sr;
        [SerializeField, TitleGroup("Required"), Required] private BoxCollider2D bc;
        [SerializeField, TitleGroup("Required"), Required] private GameObject explosionPrefab;
        [SerializeField, TitleGroup("Required"), Required] private DregsInstantiator dregsInstantiator;
        [SerializeField, TitleGroup("Sprite")] private Sprite[] spritesPerHp;

        private int hp = 3;

        void IDamage.Damage(float damage, EDamageType damageType)
        {
            if (hp <= 0) return;

            if (damageType == EDamageType.Bomb) hp = 0;
            if (damageType == EDamageType.Tear) hp -= 1;

            sr.sprite = spritesPerHp[hp];

            if (hp == 0)
            {
                sr.sortingLayerID = SortingLayer.NameToID("LowerGround");
                InstantiateExplosion();
                InstantiateDregs();
                DestroyBoxCollider();
            }
        }

        private void InstantiateExplosion()
        {
            Instantiate(explosionPrefab, this.transform.position + new Vector3(0.0f, -0.5f, 0.0f), Quaternion.identity);
        }

        private void InstantiateDregs()
        {
            dregsInstantiator.InstantitateDregs();
        }

        private void DestroyBoxCollider()
        {
            Destroy(bc);
        }
    }
}