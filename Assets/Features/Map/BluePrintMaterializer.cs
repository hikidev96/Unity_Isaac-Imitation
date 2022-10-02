using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace II
{
    public class BluePrintMaterializer : MonoBehaviour
    {
        [SerializeField] private BluePrint bluePrint;
        [SerializeField, TitleGroup("Door")] private GameObject normalDoorPrefab;
        [SerializeField, TitleGroup("Door")] private GameObject bossDoorPrefab;
        [SerializeField, TitleGroup("Door")] private GameObject shopDoorPrefab;
        [SerializeField, TitleGroup("Door")] private GameObject treasureDoorPrefab;
        [SerializeField, TitleGroup("Room")] private GameObject firstRoomPrefab;
        [SerializeField, TitleGroup("Room")] private List<GameObject> normalRoomPrefabs;
        [SerializeField, TitleGroup("Room")] private List<GameObject> bossRoomPrefabs;
        [SerializeField, TitleGroup("Room")] private List<GameObject> shopRoomPrefabs;
        [SerializeField, TitleGroup("Room")] private List<GameObject> treasureRoomPrefabs;

        private List<Room> rooms = new List<Room>();

        private void Start()
        {
            InstantiateRooms();
            InstantiateDoors();
            LinkDoors();
        }

        private void InstantiateRooms()
        {
            for (int i = 0; i < bluePrint.RoomData.Count; ++i)
            {
                var pos = bluePrint.GetPositionByRoomNumber(bluePrint.RoomData[i].RoomNumber) * 20.0f;
                Room newRoom = null;

                if (bluePrint.RoomData[i].RoomNumber == bluePrint.START_ROOM_NUMBER)
                {
                    newRoom = Room.Create(firstRoomPrefab, pos, bluePrint.RoomData[i]);
                    rooms.Add(newRoom);
                    continue;
                }

                switch (bluePrint.RoomData[i].RoomType)
                {
                    case ERoomType.Normal:
                        newRoom = Room.Create(GetNormalRoomPrefab(), pos, bluePrint.RoomData[i]);
                        break;
                    case ERoomType.Boss:
                        newRoom = Room.Create(GetBossRoomPrefab(), pos, bluePrint.RoomData[i]);
                        break;
                    case ERoomType.Shop:
                        newRoom = Room.Create(GetShopRoomPrefab(), pos, bluePrint.RoomData[i]);
                        break;
                    case ERoomType.Treasure:
                        newRoom = Room.Create(GetTreasureRoomPrefab(), pos, bluePrint.RoomData[i]);
                        break;
                    default:
                        LogHelper.ShowDefaultCaseLog();
                        break;
                }

                rooms.Add(newRoom);
            }
        }

        private void InstantiateDoors()
        {
            for (int i = 0; i < rooms.Count; ++i)
            {
                if (bluePrint.Contain(rooms[i].RoomData.RoomNumber + 10) == true)
                {
                    var doorPrefab = GetDoorPrefabByRoomType(rooms[i].RoomData.RoomType, bluePrint.GetRoomDataByRoomNumber(rooms[i].RoomData.RoomNumber + 10).RoomType);
                    rooms[i].AddDoor(EDoorDir.Top, Door.Create(rooms[i], doorPrefab, rooms[i].TopDoorSpot.position, rooms[i].TopDoorSpot.rotation, rooms[i].DoorParent));
                }
                if (bluePrint.Contain(rooms[i].RoomData.RoomNumber - 10) == true)
                {
                    var doorPrefab = GetDoorPrefabByRoomType(rooms[i].RoomData.RoomType, bluePrint.GetRoomDataByRoomNumber(rooms[i].RoomData.RoomNumber - 10).RoomType);
                    rooms[i].AddDoor(EDoorDir.Bottom, Door.Create(rooms[i], doorPrefab, rooms[i].BottomDoorSpot.position, rooms[i].BottomDoorSpot.rotation, rooms[i].DoorParent));
                }
                if (bluePrint.Contain(rooms[i].RoomData.RoomNumber + 1) == true)
                {
                    var doorPrefab = GetDoorPrefabByRoomType(rooms[i].RoomData.RoomType, bluePrint.GetRoomDataByRoomNumber(rooms[i].RoomData.RoomNumber + 1).RoomType);
                    rooms[i].AddDoor(EDoorDir.Right, Door.Create(rooms[i], doorPrefab, rooms[i].RightDoorSpot.position, rooms[i].RightDoorSpot.rotation, rooms[i].DoorParent));
                }
                if (bluePrint.Contain(rooms[i].RoomData.RoomNumber - 1) == true)
                {
                    var doorPrefab = GetDoorPrefabByRoomType(rooms[i].RoomData.RoomType, bluePrint.GetRoomDataByRoomNumber(rooms[i].RoomData.RoomNumber - 1).RoomType);
                    rooms[i].AddDoor(EDoorDir.Left, Door.Create(rooms[i], doorPrefab, rooms[i].LeftDoorSpot.position, rooms[i].LeftDoorSpot.rotation, rooms[i].DoorParent));
                }
            }
        }

        private void LinkDoors()
        {
            for (int i = 0; i < rooms.Count; ++i)
            {
                if (bluePrint.Contain(rooms[i].RoomData.RoomNumber + 10) == true)
                {
                    rooms[i].TopDoor.SetOutDoor(GetRoomByRoomNumber(rooms[i].RoomData.RoomNumber + 10).BottomDoor);
                }
                if (bluePrint.Contain(rooms[i].RoomData.RoomNumber - 10) == true)
                {
                    rooms[i].BottomDoor.SetOutDoor(GetRoomByRoomNumber(rooms[i].RoomData.RoomNumber - 10).TopDoor);
                }
                if (bluePrint.Contain(rooms[i].RoomData.RoomNumber + 1) == true)
                {
                    rooms[i].RightDoor.SetOutDoor(GetRoomByRoomNumber(rooms[i].RoomData.RoomNumber + 1).LeftDoor);
                }
                if (bluePrint.Contain(rooms[i].RoomData.RoomNumber - 1) == true)
                {
                    rooms[i].LeftDoor.SetOutDoor(GetRoomByRoomNumber(rooms[i].RoomData.RoomNumber - 1).RightDoor);
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

        private GameObject GetDoorPrefabByRoomType(ERoomType here, ERoomType neighbour)
        {
            if (here == ERoomType.Shop) return normalDoorPrefab;
            if (here == ERoomType.Boss || neighbour == ERoomType.Boss) return bossDoorPrefab;
            if (here == ERoomType.Treasure || neighbour == ERoomType.Treasure) return treasureDoorPrefab;
            if (here == ERoomType.Normal && neighbour == ERoomType.Shop) return shopDoorPrefab;

            return normalDoorPrefab;
        }

        private Room GetRoomByRoomNumber(int roomNumber)
        {
            for (int i = 0; i < rooms.Count; ++i)
            {
                if (rooms[i].RoomData.RoomNumber == roomNumber) return rooms[i];    
            }

            return null;
        }
    }
}