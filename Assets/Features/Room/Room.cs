using UnityEngine;

namespace II
{
    public enum ERoomType
    {
        Normal,        
        Boss,
        Shop,
        Treasure,
    }

    public class RoomData
    {
        public int RoomNumber;
        public ERoomType RoomType;
    }

    public class Room : MonoBehaviour
    {

    }
}