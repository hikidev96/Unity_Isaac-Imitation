using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

namespace II
{
    public class CameraManager : MonoBehaviour
    {        
        [Button("Move Camera To Room"), TitleGroup("Debug")]
        public void MoveCameraToRoom(Room dest)
        {
            Camera.main.transform.DOMove(new Vector3(dest.transform.position.x, dest.transform.position.y, -10.0f), 0.25f);
        }
    }
}