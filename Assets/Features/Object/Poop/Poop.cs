using UnityEngine;

namespace II
{
    public class Poop : MonoBehaviour, IDamage
    {
        [SerializeField] private Sprite[] spritesPerHp;
        [SerializeField] private SpriteRenderer sr;
        [SerializeField] private BoxCollider2D bc;

        private int hp = 4;

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
                Destroy(bc);
            }
        }
    }
}
