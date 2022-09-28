using UnityEngine;
using Sirenix.OdinInspector;

namespace II
{
    public class Item : MonoBehaviour
    {
        [SerializeField, PreviewField] private Sprite itemImage;
        [SerializeField] private string itemName;
        [SerializeField] private string itemQuote;

        public Sprite ItemImage => itemImage;
        public string ItemName => itemName;
        public string ItemQuote => itemQuote;
    }
}
