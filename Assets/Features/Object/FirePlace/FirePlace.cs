using UnityEngine;

namespace II
{
    public class FirePlace : MonoBehaviour, IDamage
    {
        [SerializeField] private Transform fireTransform;
        [SerializeField] private GameObject firePoofPrefab;

        private int hp = 4;

        void IDamage.Damage(float damage, EDamageType damageType)
        {
            if (hp <= 0) return;

            if (damageType == EDamageType.Bomb) hp = 0;
            if (damageType == EDamageType.Tear) hp -= 1;

            if (hp == 3) fireTransform.localScale = new Vector2(0.8f, 0.8f);
            if (hp == 2) fireTransform.localScale = new Vector2(0.7f, 0.7f);
            if (hp == 1) fireTransform.localScale = new Vector2(0.5f, 0.5f);
            if (hp == 0)
            {
                Instantiate(firePoofPrefab, this.transform.position, Quaternion.identity);
                Destroy(fireTransform.gameObject);
            }
        }
    }
}
