using UnityEngine;

namespace II
{
    public class ShopProduct : MonoBehaviour
    {
        private Pickup pickup;
        private Rigidbody2D rb;
        private GameObject priceTextObj;
        private int price;

        private void Awake()
        {
            pickup = GetComponent<Pickup>();
            rb = GetComponent<Rigidbody2D>();   
        }

        private void Start()
        {
            pickup.enabled = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        public void SetPrice(int price)
        {
            this.price = price;
        }

        public void SetPriceTextObj(GameObject priceTextObj)
        {
            this.priceTextObj = priceTextObj;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var isaac = collision.gameObject.GetComponent<Isaac>();

            if (isaac != null)
            {
                if (Isaac.Instance.TryUseCoin(price) == true)
                {
                    pickup.Pickuped();
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    Destroy(priceTextObj);
                }
            }
        }
    }
}
