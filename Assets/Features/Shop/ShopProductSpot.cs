using UnityEngine;

namespace II
{
    [System.Serializable]
    public class ShopProductSpotData
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int price;

        public GameObject Prefab => prefab;
        public int Price => price;
    }

    public class ShopProductSpot : MonoBehaviour
    {
        [SerializeField] private ShopProductSpotData[] shopProductCandidates;
        [SerializeField] private GameObject priceTextPrefab;

        private void Start()
        {
            var shopProductSpotData = shopProductCandidates[Random.Range(0, shopProductCandidates.Length)];
            var shopProductObj = Instantiate(shopProductSpotData.Prefab, this.transform.position, Quaternion.identity);
            var shopProduct = shopProductObj.AddComponent<ShopProduct>();

            var priceTextObj = Instantiate(priceTextPrefab, this.transform.position - new Vector3(0.0f, 0.6f, 0.0f), Quaternion.identity);
            var priceText = priceTextObj.GetComponent<PriceText>();

            shopProduct.SetPrice(shopProductSpotData.Price);
            shopProduct.SetPriceTextObj(priceTextObj);
            priceText.SetPrice(shopProductSpotData.Price);
        }
    }
}