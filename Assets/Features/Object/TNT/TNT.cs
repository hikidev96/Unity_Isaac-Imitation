using UnityEngine;

namespace II
{
    public class TNT : MonoBehaviour, IDamage
    {
        [SerializeField] private Sprite[] spritesPerHp;
        [SerializeField] private SpriteRenderer sr;
        [SerializeField] private BoxCollider2D bc;
        [SerializeField] private GameObject explosionPrefab;

        private int hp = 3;

        void IDamage.Damage(float damage, EDamageType damageType)
        {
            if (hp <= 0) return;

            if (damageType == EDamageType.Bomb) hp = 0;
            if (damageType == EDamageType.Tear) hp -= 1;

            if (hp == 3) sr.sprite = spritesPerHp[hp];
            if (hp == 2) sr.sprite = spritesPerHp[hp];
            if (hp == 1) sr.sprite = spritesPerHp[hp];
            if (hp == 0)
            {
                sr.sprite = spritesPerHp[hp];
                sr.sortingLayerID = SortingLayer.NameToID("GroundSurface");
                Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
                Destroy(bc);
            }
        }
    }
}
