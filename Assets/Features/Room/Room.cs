using UnityEngine;
using Sirenix.OdinInspector;

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
        public bool IsCleared;
    }

    public class Room : MonoBehaviour
    {
        [SerializeField] private Transform leftDoorSpot;
        [SerializeField] private Transform rightDoorSpot;
        [SerializeField] private Transform topDoorSpot;
        [SerializeField] private Transform bottomDoorSpot;
        [SerializeField] private Transform doorParent;

        [SerializeField] private GameObject leftDoorCollider;
        [SerializeField] private GameObject rightDoorCollider;
        [SerializeField] private GameObject topDoorCollider;
        [SerializeField] private GameObject bottomDoorCollider;

        private Door leftDoor;
        private Door rightDoor;
        private Door topDoor;
        private Door bottomDoor;

        public Transform LeftDoorSpot => leftDoorSpot;
        public Transform RightDoorSpot => rightDoorSpot;
        public Transform TopDoorSpot => topDoorSpot;
        public Transform BottomDoorSpot => bottomDoorSpot;

        public Door LeftDoor => leftDoor;
        public Door RightDoor => rightDoor;
        public Door TopDoor => topDoor;
        public Door BottomDoor => bottomDoor;
        public Transform DoorParent => doorParent;  

        private RoomData roomData;

        public RoomData RoomData => roomData;

        public static Room Create(GameObject prefab, Vector2 pos, RoomData roomData)
        {
            var newRoom = Instantiate(prefab, pos, Quaternion.identity).GetComponent<Room>();
            newRoom.roomData = roomData;
            return newRoom;
        }

        [Button("Clear"), TitleGroup("Debug")]
        public void Clear()
        {
            OpenAllDoor();

            roomData.IsCleared = true;
        }

        public void AddDoor(EDoorDir doorDir, Door door)
        {
            switch (doorDir)
            {
                case EDoorDir.Left:
                    leftDoor = door;
                    break;
                case EDoorDir.Right:
                    rightDoor = door;
                    break;
                case EDoorDir.Top:
                    topDoor = door;
                    break;
                case EDoorDir.Bottom:
                    bottomDoor = door;
                    break;
                default:
                    LogHelper.ShowDefaultCaseLog();
                    break;
            }
        }

        [Button("Open All Door"), TitleGroup("Debug")]
        private void OpenAllDoor()
        {
            if (leftDoor != null)
            {
                leftDoor.Open();
                leftDoorCollider.SetActive(false);
            }
            if (rightDoor != null)
            {
                rightDoor.Open();
                rightDoorCollider.SetActive(false);
            }
            if (topDoor != null)
            {
                topDoor.Open();
                topDoorCollider.SetActive(false);
            }
            if (bottomDoor != null)
            {
                bottomDoor.Open();
                bottomDoorCollider.SetActive(false);
            }
        }

        [Button("Close All Door"), TitleGroup("Debug")]
        private void CloseAllDoor()
        {
            rightDoor?.Close();
            leftDoor?.Close();
            topDoor?.Close();
            bottomDoor?.Close();
        }
    }
}