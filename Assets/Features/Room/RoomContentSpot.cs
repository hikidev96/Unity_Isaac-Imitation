using System.Collections.Generic;
using UnityEngine;

namespace II
{
    public enum ERoomContentSize
    {
        OneByOne,
    }

    public class RoomContentSpot : MonoBehaviour
    {
        [SerializeField] private List<GameObject> roomContentPrefabs;
        [SerializeField] private ERoomContentSize roomContentSize;

        public void InstantiateContent()
        {

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            switch (roomContentSize)
            {
                case ERoomContentSize.OneByOne:
                    Gizmos.DrawWireCube(this.transform.position, new Vector2(1.0f, 1.0f));
                    break;
                default:
                    LogHelper.ShowDefaultCaseLog();
                    break;
            }            
        }
    }
}