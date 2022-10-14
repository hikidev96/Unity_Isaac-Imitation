using UnityEngine;

namespace II
{
    public class GroundMonster : Monster
    {
        [SerializeField] private GameObject bloodPoofPrefab;

        protected override void Awake()
        {
            base.Awake();

            onDie.AddListener(() =>
            {
                Instantiate(bloodPoofPrefab, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            });
        }
    }
}
