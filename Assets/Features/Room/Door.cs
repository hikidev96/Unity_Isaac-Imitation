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

        private Door outDoor;        

        public static Door Create(GameObject prefab, Vector2 pos, Quaternion rot, Transform parent)
        {
            var newDoor = Instantiate(prefab, pos, rot, parent).GetComponent<Door>();
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
    }
}