using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace II
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] protected Transform viewTrans;

        private Tweener scaleTweener_I;
        private Tweener moveUpTweener_I;
        private Tweener moveDownTweener_I;
        private Tweener punchTweener_I;
        private Tweener sacleTweener_P;

        protected virtual void Start()
        {
            StartCoroutine(PlayInstantiationAnimation());
        }

        private void OnDestroy()
        {
            scaleTweener_I.Kill();
            moveUpTweener_I.Kill();
            moveDownTweener_I.Kill();
            punchTweener_I.Kill();
            sacleTweener_P.Kill();
        }

        public virtual void Pickuped()
        {
            StartCoroutine(PlayPickupAnimation());
        }

        protected IEnumerator PlayInstantiationAnimation()
        {
            viewTrans.localScale = new Vector2(0.2f, 1.5f);
            scaleTweener_I = viewTrans.DOScale(Vector2.one, 0.3f).SetEase(Ease.InOutElastic);
            moveUpTweener_I = viewTrans.DOLocalMoveY(1.0f, 0.3f).SetEase(Ease.OutExpo);

            yield return new WaitForSeconds(0.3f);

            moveDownTweener_I = viewTrans.DOLocalMoveY(0.0f, 0.3f).SetEase(Ease.InExpo);

            yield return new WaitForSeconds(0.3f);

            punchTweener_I = viewTrans.DOPunchScale(new Vector2(0.5f, 0.2f), 0.3f);
        }

        protected IEnumerator PlayPickupAnimation()
        {
            sacleTweener_P = this.transform.DOScale(new Vector2(2.0f, 0.1f), 0.1f);
            
            yield return new WaitForSeconds(0.1f);

            Destroy(this.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (this.enabled == false) return;

            var isaac = collision.gameObject.GetComponent<Isaac>();

            if (isaac != null)
            {
                Pickuped();
            }
        }
    }
}