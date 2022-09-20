using System.Collections.Generic;
using UnityEngine;

namespace II
{
    public class MapInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject firstRoomPrefab;
        [SerializeField] private List<GameObject> normalRoomPrefabs;
        [SerializeField] private List<GameObject> bossRoomPrefabs;
        [SerializeField] private List<GameObject> shopRoomPrefabs;
        [SerializeField] private List<GameObject> treasureRoomPrefabs;
        [SerializeField] private BluePrint bluePrint;

        private void Start()
        {
            for (int i = 0; i < bluePrint.RoomData.Count; ++i)
            {
                var pos = bluePrint.GetPositionFromRoomNumber(bluePrint.RoomData[i].RoomNumber) * 20.0f;

                if (bluePrint.RoomData[i].RoomNumber == bluePrint.START_ROOM_NUMBER)
                {
                    Instantiate(firstRoomPrefab, pos, Quaternion.identity);
                    continue;
                }

                switch (bluePrint.RoomData[i].RoomType)
                {
                    case ERoomType.Normal:
                        Instantiate(GetNormalRoomPrefab(), pos, Quaternion.identity);
                        break;
                    case ERoomType.Boss:
                        Instantiate(GetBossRoomPrefab(), pos, Quaternion.identity);
                        break;
                    case ERoomType.Shop:
                        Instantiate(GetShopRoomPrefab(), pos, Quaternion.identity);
                        break;
                    case ERoomType.Treasure:
                        Instantiate(GetTreasureRoomPrefab(), pos, Quaternion.identity);
                        break;
                    default:
                        LogHelper.ShowDefaultCaseLog();
                        break;
                }                
            }
        }
        
        private GameObject GetNormalRoomPrefab()
        {
            return normalRoomPrefabs[Random.Range(0, normalRoomPrefabs.Count)];
        }

        private GameObject GetBossRoomPrefab()
        {
            return bossRoomPrefabs[Random.Range(0, bossRoomPrefabs.Count)];
        }

        private GameObject GetShopRoomPrefab()
        {
            return shopRoomPrefabs[Random.Range(0, shopRoomPrefabs.Count)];
        }

        private GameObject GetTreasureRoomPrefab()
        {
            return treasureRoomPrefabs[Random.Range(0, treasureRoomPrefabs.Count)];
        }
    }
}