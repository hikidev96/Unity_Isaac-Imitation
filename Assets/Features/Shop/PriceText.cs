using UnityEngine;
using TMPro;

namespace II
{
    public class PriceText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI priceTmp;

        public void SetPrice(int price)
        {
            priceTmp.text = price.ToString() + "C";
        }
    }
}
