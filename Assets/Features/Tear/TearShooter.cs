using UnityEngine;

namespace II
{
    public class TearShooter : MonoBehaviour
    {
        [SerializeField] private GameObject tearPrefab;

        public void Shoot(Vector2 to)
        {
            var tear = Instantiate(tearPrefab, this.transform.position, Quaternion.identity).GetComponent<Tear>();
            tear.SetDir(VectorHelper.Get2Dir(this.transform.position, to));
        }

        public void Shoot()
        {
            var tear = Instantiate(tearPrefab, this.transform.position, Quaternion.identity).GetComponent<Tear>();
        }
    }
}