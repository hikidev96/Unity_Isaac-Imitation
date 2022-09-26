using System.Collections.Generic;
using UnityEngine;

namespace II
{
    public class Rock : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sr;
        [SerializeField] private List<Sprite> sprites;

        private void Awake()
        {
            sr.sprite = sprites[Random.Range(0, sprites.Count)];
        }
    }
}