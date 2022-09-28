using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace II
{
    public enum EDoorDir
    {
        Left = 0,
        Right = 1,
        Top = 2,
        Bottom = 3
    }

    public class Door : MonoBehaviour
    {
        [SerializeField] private Transform leftDoorLeaf;
        [SerializeField] private Transform rightDoorLeaf;
        [SerializeField] private Transform shiftSpot;
        [SerializeField] private bool isLockedDoor;

        private Room belongRoom;
        private Door outDoor;        

        public Room BelongRoom => belongRoom;
        public Transform ShiftSpot => shiftSpot;
        public bool IsLockedDoor => isLockedDoor;   

        public static Door Create(Room belongRoom, GameObject prefab, Vector2 pos, Quaternion rot, Transform parent)
        {
            var newDoor = Instantiate(prefab, pos, rot, parent).GetComponent<Door>();
            newDoor.belongRoom = belongRoom;
            return newDoor;
        }

        [Button("Open"), TitleGroup("Debug")]
        public void Open()
        {
            leftDoorLeaf.DOLocalMoveX(-0.1f, 0.05f).onComplete += () => leftDoorLeaf.gameObject.SetActive(false);
            rightDoorLeaf.DOLocalMoveX(0.1f, 0.05f).onComplete += () => rightDoorLeaf.gameObject.SetActive(false);
        }

        [Button("Close"), TitleGroup("Debug")]
        public void Close()
        {
            leftDoorLeaf.gameObject.SetActive(true);
            rightDoorLeaf.gameObject.SetActive(true);

            leftDoorLeaf.DOLocalMoveX(0.0f, 0.05f);
            rightDoorLeaf.DOLocalMoveX(0.0f, 0.05f);
        }

        public void SetOutDoor(Door outDoor)
        {
            this.outDoor = outDoor;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Isaac") == true)
            {
                collision.transform.position = outDoor.shiftSpot.position;
                Manager.Camera.MoveCameraToRoom(outDoor.BelongRoom);
            }
        }
    }
}