using System.Collections.Generic;
using UnityEngine;

namespace II
{
    public class HUDMinimap : MonoBehaviour
    {
        [SerializeField] private BluePrint bluePrint;
        [SerializeField] private GameObject minimapRoomPrefab;
        [SerializeField] private GameObject minimapCameraObj;

        private List<MinimapRoom> minimapRooms = new List<MinimapRoom>();

        private void Start()
        {
            for (int i = 0; i < bluePrint.RoomData.Count; ++i)
            {
                var pos = bluePrint.GetPositionByRoomNumber(bluePrint.RoomData[i].RoomNumber);
                var correctedPos = new Vector2(pos.x / 3.0f, pos.y / 4.0f);
                var minimapRoom = Instantiate(minimapRoomPrefab, correctedPos, Quaternion.identity).GetComponent<MinimapRoom>();
                minimapRoom.SetRoomData(bluePrint.RoomData[i]);
                minimapRoom.SetMinimapCameraObj(minimapCameraObj);

                minimapRooms.Add(minimapRoom);
            }

            for (int i = 0; i < minimapRooms.Count; ++i)
            {
                var upNeighbour = GetMinimapRoomByNumber(minimapRooms[i].RoomData.RoomNumber + 10);
                var bottomNeighbour = GetMinimapRoomByNumber(minimapRooms[i].RoomData.RoomNumber - 10);
                var rightNeighbour = GetMinimapRoomByNumber(minimapRooms[i].RoomData.RoomNumber + 1);
                var leftNeighbour = GetMinimapRoomByNumber(minimapRooms[i].RoomData.RoomNumber - 1);

                if (upNeighbour != null) minimapRooms[i].AddNeighbour(GetMinimapRoomByNumber(minimapRooms[i].RoomData.RoomNumber + 10));
                if (bottomNeighbour != null) minimapRooms[i].AddNeighbour(GetMinimapRoomByNumber(minimapRooms[i].RoomData.RoomNumber - 10));
                if (rightNeighbour != null) minimapRooms[i].AddNeighbour(GetMinimapRoomByNumber(minimapRooms[i].RoomData.RoomNumber + 1));
                if (leftNeighbour != null) minimapRooms[i].AddNeighbour(GetMinimapRoomByNumber(minimapRooms[i].RoomData.RoomNumber - 1));
            }
        }

        private MinimapRoom GetMinimapRoomByNumber(int roomNumber)
        {
            for (int i = 0; i < minimapRooms.Count; ++i)
            {
                if (minimapRooms[i].RoomData.RoomNumber == roomNumber)
                {
                    return minimapRooms[i];
                }
            }

            return null;
        }
    }
}
