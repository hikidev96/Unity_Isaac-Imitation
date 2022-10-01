using UnityEngine;
using TMPro;

namespace II
{
    public class HUDPickups : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI CoinTMP;
        [SerializeField] private TextMeshProUGUI BombTMP;
        [SerializeField] private TextMeshProUGUI KeyTMP;

        private void Update()
        {
            CoinTMP.text = Isaac.Instance.CoinCount.ToString();
            BombTMP.text = Isaac.Instance.BombCount.ToString();
            KeyTMP.text = Isaac.Instance.KeyCount.ToString();
        }
    }
}
