using UnityEngine;
using DG.Tweening;

namespace II
{
    public class Bomb : Pickup
    {
        [SerializeField] private SpriteRenderer viewSR;
        [SerializeField] private GameObject explosionPrefab;

        private bool isThrew;
        private Tweener viewSRColorTween;
        private Tweener viewTransPunchTween;

        protected override void Start()
        {
            if (isThrew == true)
            {

            }
            else
            {
                StartCoroutine(PlayInstantiationAnimation());
            }            
        }

        private void OnDestroy()
        {
            viewSRColorTween.Kill();
            viewTransPunchTween.Kill();
        }

        public void Throw()
        {
            if (isThrew == true) return;

            viewSRColorTween = viewSR.DOColor(Color.red, 0.2f).SetLoops(-1, LoopType.Yoyo);
            viewTransPunchTween = viewTrans.DOPunchScale(new Vector2(0.2f, 0.2f), 0.2f).SetLoops(-1);

            Invoke("Explode", 1.5f);

            isThrew = true;
        }

        protected override void Pickuped()
        {
            if (isThrew == true) return;

            base.Pickuped();

            Isaac.Instance.AddBomb(1);
        }

        private void Explode()
        {
            Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
