using UnityEngine;
using UnityEngine.UI;

namespace II
{
    public class HUDHearts : MonoBehaviour
    {
        [SerializeField] private Sprite emptyHeartSprite;
        [SerializeField] private Sprite halfHeartSprite;
        [SerializeField] private Sprite fullHeartSprite;
        [SerializeField] private GameObject heartImagePrefab;

        private void Start()
        {
            int fullHeartCount = Isaac.Instance.MaxHeartCount / 2;
            bool isThereHalfHeart = Isaac.Instance.MaxHeartCount % 2 == 1;

            for (int i = 0; i < fullHeartCount; ++i)
            {
                var heartImage = Instantiate(heartImagePrefab, this.transform).GetComponent<Image>();
                heartImage.sprite = fullHeartSprite;
            }

            if (isThereHalfHeart == true)
            {
                var heartImage = Instantiate(heartImagePrefab, this.transform).GetComponent<Image>();
                heartImage.sprite = halfHeartSprite;
            }

            Isaac.Instance.OnHeartAdd.AddListener(AddHeart);
            Isaac.Instance.OnHeartRecover.AddListener(RecoverHeart);
            Isaac.Instance.OnHeartDamage.AddListener(DamageHeart);
        }

        private void AddHeart()
        {
            var heartImage = Instantiate(heartImagePrefab, this.transform).GetComponent<Image>();
            heartImage.sprite = emptyHeartSprite;
            RecoverHeart(2);
        }

        private void RecoverHeart(int amount)
        {
            for (int i = 0; i < this.transform.childCount; ++i)
            {
                if (amount == 0) return;                    

                var heartImage = this.transform.GetChild(i).GetComponent<Image>();

                if (heartImage.sprite == emptyHeartSprite)
                {
                    if (amount >= 2)
                    {
                        heartImage.sprite = fullHeartSprite;
                        amount -= 2;
                    }
                    else if (amount == 1)
                    {
                        heartImage.sprite = halfHeartSprite;
                        amount -= 1;
                    }
                }
                else if (heartImage.sprite == halfHeartSprite)
                {
                    heartImage.sprite = fullHeartSprite;
                    amount -= 1;
                }
            }
        }

        private void DamageHeart()
        {
            for (int i = this.transform.childCount - 1; i >= 0; --i)
            {
                var heartImage = this.transform.GetChild(i).GetComponent<Image>();

                if (heartImage.sprite == fullHeartSprite)
                {
                    heartImage.sprite = halfHeartSprite;
                    return;
                }
                else if (heartImage.sprite == halfHeartSprite)
                {
                    heartImage.sprite = emptyHeartSprite;
                    return;
                }
            }
        }
    }
}