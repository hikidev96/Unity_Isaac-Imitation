using UnityEngine;
using DG.Tweening;

namespace II
{
    public class DoorKeyHole : MonoBehaviour
    {
        [SerializeField] private Door door;
        [SerializeField] private EdgeCollider2D ec;
        [SerializeField] private GameObject key;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Isaac") == true)
            {
                TryUnlock();
            }
        }

        private void TryUnlock()
        {
            if (Isaac.Instance.TryUseKey() == true)
            {
                door.Open();
                StartCoroutine(PlayUnlockAnimation());
                Destroy(ec);
            }
        }

        private System.Collections.IEnumerator PlayUnlockAnimation()
        {
            key.SetActive(true);
            key.transform.DOLocalMoveY(0.5f, 0.2f);

            yield return new WaitForSeconds(0.2f);

            key.SetActive(false);
        }
    }
}