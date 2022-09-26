using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace II
{
    public class Rock : MonoBehaviour, IDamage
    {
        [SerializeField] private SpriteRenderer sr;
        [SerializeField] private DregsInstantiator dregsInstantiator;   
        [SerializeField] private List<Sprite> sprites;        

        private void Awake()
        {
            sr.sprite = sprites[Random.Range(0, sprites.Count)];
        }

        [Button("Damage"), TitleGroup("TEST")]
        void IDamage.Damage(float damage, EDamageType damageType)
        {
            if (damageType == EDamageType.Tear) return;

            if (damageType == EDamageType.Bomb)
            {
                dregsInstantiator.InstantitateDregs();
                Destroy(this.gameObject);
            }
        }
    }
}