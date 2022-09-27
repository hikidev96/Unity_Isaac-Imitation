using UnityEngine;

namespace II
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private GameObject vestigePrefab;
        [SerializeField] private float explosionRadius;

        private void Start()
        {
            Invoke("DestroySelf", 0.3f);
            Explode();
        }

        private void Explode()
        {
            DamageToObjects();
            InstantiateVestige();
        }

        private void DestroySelf()
        {
            Destroy(gameObject);
        }

        private void InstantiateVestige()
        {
            Instantiate(vestigePrefab, this.transform.position, Quaternion.identity);
        }

        private void DamageToObjects()
        {
            var canditatesToDamage = Physics2D.OverlapCircleAll(this.transform.position, explosionRadius);

            for (int i = 0; i < canditatesToDamage.Length; ++i)
            {
                var damageableObject = canditatesToDamage[i].GetComponent<IDamage>();

                if (damageableObject != null)
                {
                    damageableObject.Damage(100.0f, EDamageType.Bomb);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(this.transform.position, explosionRadius);
        }                
    }
}