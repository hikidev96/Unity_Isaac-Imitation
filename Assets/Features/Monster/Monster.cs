using UnityEngine;
using Animancer;

namespace II
{
    public class Monster : MonoBehaviour
    {
        [SerializeField] protected AnimancerComponent animancer;

        protected Room room;

        public static Monster Create(GameObject prefab, Vector2 position, Room room)
        {
            var newMonster = Instantiate(prefab, position, Quaternion.identity).GetComponent<Monster>();
            newMonster.SetRoom(room);

            return newMonster;
        }

        public void SetRoom(Room room)
        {
            this.room = room;
        }
    }
}