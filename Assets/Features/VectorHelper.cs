using UnityEngine;

namespace II
{
    public static class VectorHelper
    {
        public static Vector2 Get2Dir(Vector2 from, Vector2 to)
        {
            return (to - from).normalized;
        }
    }
}
