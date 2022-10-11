using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Yemin.PathFinding;

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
        public bool IsVisited;
        public UnityEvent OnIsaacEnter = new UnityEvent();
        public UnityEvent OnIsaacExit = new UnityEvent();
    }

    public class Room : MonoBehaviour
    {
        [SerializeField] private Transform leftDoorSpot;
        [SerializeField] private Transform rightDoorSpot;
        [SerializeField] private Transform topDoorSpot;
        [SerializeField] private Transform bottomDoorSpot;
        [SerializeField] private Transform doorParent;
        [SerializeField] private Transform roomMonsterSpotParent;

        [SerializeField] private GameObject leftDoorCollider;
        [SerializeField] private GameObject rightDoorCollider;
        [SerializeField] private GameObject topDoorCollider;
        [SerializeField] private GameObject bottomDoorCollider;

        [SerializeField] private PathFinding pathFinding;

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
        public PathFinding PathFinding => pathFinding;

        private RoomData roomData;

        public RoomData RoomData => roomData;

        private void Start()
        {
            if (roomMonsterSpotParent.childCount == 0)
            {
                Clear();
            }

            InstantiateAllRoomObjects();
            pathFinding.Init();
        }

        public static Room Create(GameObject prefab, Vector2 pos, RoomData roomData)
        {
            var newRoom = Instantiate(prefab, pos, Quaternion.identity).GetComponent<Room>();
            newRoom.roomData = roomData;
            return newRoom;
        }

        [Button("Clear"), TitleGroup("Debug")]
        public void Clear()
        {
            DeactivateAllDoorCollider();
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
            if (leftDoor != null && leftDoor.IsLockedDoor == false)
            {
                leftDoor.Open();
            }
            if (rightDoor != null && rightDoor.IsLockedDoor == false)
            {
                rightDoor.Open();
            }
            if (topDoor != null && topDoor.IsLockedDoor == false)
            {
                topDoor.Open();
            }
            if (bottomDoor != null && bottomDoor.IsLockedDoor == false)
            {
                bottomDoor.Open();
            }
        }

        private void DeactivateAllDoorCollider()
        {
            if (leftDoor != null)
            {
                leftDoorCollider.SetActive(false);
            }
            if (rightDoor != null)
            {
                rightDoorCollider.SetActive(false);
            }
            if (topDoor != null)
            {
                topDoorCollider.SetActive(false);
            }
            if (bottomDoor != null)
            {
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

        private void InstantiateAllRoomObjects()
        {
            var spots = GetComponentsInChildren<RoomObjectSpot>();

            foreach (var spot in spots)
            {
                spot.InstantiateObject();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Isaac>() !=null)
            {
                roomData.OnIsaacEnter.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.GetComponent<Isaac>() != null)
            {
                roomData.OnIsaacExit.Invoke();
            }
        }
    }
}