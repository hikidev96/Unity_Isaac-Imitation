using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace II
{
    public class MinimapRoom : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer roomSR;
        [SerializeField] private SpriteRenderer iconSR;

        [SerializeField] private Sprite unvisitedSprite;
        [SerializeField] private Sprite visitedSprite;
        [SerializeField] private Sprite visitingSprite;
        [SerializeField] private Sprite treasureIconSprite;
        [SerializeField] private Sprite bossIconSprite;
        [SerializeField] private Sprite shopIconSprite;

        private RoomData roomData;
        private GameObject minimapCameraObj;
        private List<MinimapRoom> neighbours = new List<MinimapRoom>();

        public RoomData RoomData => roomData;

        public void SetMinimapCameraObj(GameObject minimapCameraObj)
        {
            this.minimapCameraObj = minimapCameraObj;
        }

        public void SetRoomData(RoomData roomData)
        {
            this.roomData = roomData;

            switch (roomData.RoomType)
            {
                case ERoomType.Normal:
                    break;
                case ERoomType.Shop:
                    SetIconSprite(shopIconSprite);
                    break;
                case ERoomType.Treasure:
                    SetIconSprite(treasureIconSprite);
                    break;
                case ERoomType.Boss:
                    SetIconSprite(bossIconSprite);
                    break;
                default:
                    LogHelper.ShowDefaultCaseLog();
                    break;
            }

            roomData.OnIsaacEnter.AddListener(ReactToIsaacEnter);
            roomData.OnIsaacExit.AddListener(ReactToIsaacExit);
        }

        [Button, TitleGroup("TEST")]
        private void ReactToIsaacEnter()
        {
            if (this.gameObject.activeSelf == false)
            {
                this.gameObject.SetActive(true);
            }

            SetRoomSprite(visitingSprite);

            minimapCameraObj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1.0f);

            BrightenNeighbours();
        }

        [Button, TitleGroup("TEST")]
        private void ReactToIsaacExit()
        {
            SetRoomSprite(visitedSprite);
        }
        
        private void BrightenNeighbours()
        {            
            for (int i = 0; i < neighbours.Count; i++)
            {
                if (neighbours[i].gameObject.activeSelf == false)
                {
                    neighbours[i].gameObject.SetActive(true);
                }
            }
        }

        public void AddNeighbour(MinimapRoom neighbour)
        {
            neighbours.Add(neighbour);
        }

        public void SetRoomSprite(Sprite sprite)
        {
            roomSR.sprite = sprite;
        }

        public void SetIconSprite(Sprite sprite)
        {
            iconSR.sprite = sprite;
        }
    }
}
