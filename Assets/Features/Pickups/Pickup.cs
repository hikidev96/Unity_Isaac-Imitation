using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace II
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] protected Transform viewTrans;

        protected virtual void Start()
        {
            StartCoroutine(PlayInstantiationAnimation());
        }

        protected virtual void Pickuped()
        {
            StartCoroutine(PlayPickupAnimation());
        }

        protected IEnumerator PlayInstantiationAnimation()
        {
            viewTrans.localScale = new Vector2(0.2f, 1.5f);
            viewTrans.DOScale(Vector2.one, 0.3f).SetEase(Ease.InOutElastic);
            viewTrans.DOLocalMoveY(1.0f, 0.3f).SetEase(Ease.OutExpo);

            yield return new WaitForSeconds(0.3f);

            viewTrans.DOLocalMoveY(0.0f, 0.3f).SetEase(Ease.InExpo);

            yield return new WaitForSeconds(0.3f);

            viewTrans.DOPunchScale(new Vector2(0.5f, 0.2f), 0.3f);
        }

        protected IEnumerator PlayPickupAnimation()
        {
            this.transform.DOScale(new Vector2(2.0f, 0.1f), 0.1f);
            
            yield return new WaitForSeconds(0.1f);

            Destroy(this.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var isaac = collision.gameObject.GetComponent<Isaac>();

            if (isaac != null)
            {
                Pickuped();
            }
        }
    }
}