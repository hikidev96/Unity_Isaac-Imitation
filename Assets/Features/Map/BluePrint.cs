using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace II
{
    [CreateAssetMenu(menuName = "II/BluePrint")]
    public class BluePrint : ScriptableObject
    {
        public const int START_ROOM_NUMBER = 35;
        public int StageLevel = 1;

        private Queue<int> roomNumberQueue;
        private List<int> roomNumbers;
        private List<int> endRoomNumbers;
        private List<RoomData> roomData;
        private int targetRoomCount;

        public List<RoomData> RoomData => roomData;

        private void OnEnable()
        {
            StageLevel = 1;

            MakeBluePrint();
        }

        [Button("Make Blue Print")]
        public void MakeBluePrint()
        {
            Prep();
            PostProcess();
        }

        private void Prep()
        {
            targetRoomCount = (int)(Random.Range(0, 2) + 5 + StageLevel * 2.6);

            while (true)
            {
                bool isSucceed = true;

                roomNumbers = new List<int>();
                endRoomNumbers = new List<int>();
                roomNumberQueue = new Queue<int>();

                roomNumberQueue.Enqueue(START_ROOM_NUMBER);
                roomNumbers.Add(START_ROOM_NUMBER);

                while (true)
                {
                    if (roomNumberQueue.Count == 0)
                    {
                        if (IsSatisfiedTargetRoomCount() == true && IsStartRoomAndBossRoomNeighbour() == false)
                        {
                            isSucceed = true;
                        }
                        else
                        {
                            isSucceed = false;
                        }

                        break;
                    }

                    var currentRoomNumber = roomNumberQueue.Dequeue();
                    var isEndRoom = true;

                    if (TryMakeNeighbour(currentRoomNumber + 10) == true) isEndRoom = false;
                    if (TryMakeNeighbour(currentRoomNumber - 10) == true) isEndRoom = false;
                    if (TryMakeNeighbour(currentRoomNumber + 1) == true) isEndRoom = false;
                    if (TryMakeNeighbour(currentRoomNumber - 1) == true) isEndRoom = false;

                    if (isEndRoom == true)
                    {
                        endRoomNumbers.Add(currentRoomNumber);
                    }
                }

                if (isSucceed == true) break;
            }
        }

        private void PostProcess()
        {
            roomData = new List<RoomData>();

            for (int i = 0; i < roomNumbers.Count; ++i)
            {
                var newRoomData = new RoomData();
                newRoomData.RoomNumber = roomNumbers[i];

                roomData.Add(newRoomData);
            }

            var bossRoomData = GetRoomDataFromRoomNumber(endRoomNumbers[endRoomNumbers.Count - 1]);
            bossRoomData.RoomType = ERoomType.Boss;

            if (endRoomNumbers.Count >= 2)
            {
                var treasureRoom = GetRoomDataFromRoomNumber(endRoomNumbers[0]);
                treasureRoom.RoomType = ERoomType.Treasure;
            }
            if (endRoomNumbers.Count >= 3)
            {
                var shopRoom = GetRoomDataFromRoomNumber(endRoomNumbers[1]);
                shopRoom.RoomType = ERoomType.Shop;
            }
        }

        private bool TryMakeNeighbour(int roomNumber)
        {
            if (roomNumbers.Contains(roomNumber) == true) return false;
            if (GetNeighbourCount(roomNumber) >= 2) return false;
            if (IsSatisfiedTargetRoomCount() == true) return false;
            if (Random.Range(0, 2) == 0) return false;
            if (roomNumber < 0) return false;
            if (roomNumber % 10 == 0) return false;

            roomNumberQueue.Enqueue(roomNumber);
            roomNumbers.Add(roomNumber);

            return true;
        }

        private bool IsSatisfiedTargetRoomCount()
        {
            return targetRoomCount == roomNumbers.Count;
        }

        private bool IsStartRoomAndBossRoomNeighbour()
        {
            var bossRoomNumber = endRoomNumbers[endRoomNumbers.Count - 1];

            if (bossRoomNumber == START_ROOM_NUMBER + 10) return true;
            if (bossRoomNumber == START_ROOM_NUMBER - 10) return true;
            if (bossRoomNumber == START_ROOM_NUMBER + 1) return true;
            if (bossRoomNumber == START_ROOM_NUMBER - 1) return true;

            return false;
        }

        private int GetNeighbourCount(int roomNumber)
        {
            int result = 0;

            if (roomNumbers.Contains(roomNumber + 10) == true) result++;
            if (roomNumbers.Contains(roomNumber - 10) == true) result++;
            if (roomNumbers.Contains(roomNumber + 1) == true) result++;
            if (roomNumbers.Contains(roomNumber - 1) == true) result++;

            return result;
        }

        private RoomData GetRoomDataFromRoomNumber(int roomNumber)
        {
            for (int i = 0; i < roomData.Count; ++i)
            {
                if (roomData[i].RoomNumber == roomNumber)
                    return roomData[i];
            }

            return null;
        }

        public Vector2 GetPositionFromRoomNumber(int roomNumber)
        {
            return new Vector2(roomNumber % 10, roomNumber / 10);
        }
    }
}