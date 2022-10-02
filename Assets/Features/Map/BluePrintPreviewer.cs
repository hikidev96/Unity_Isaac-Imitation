using UnityEngine;
using UnityEditor;

namespace II
{
    public class BluePrintPreviewer : MonoBehaviour
    {
        [SerializeField] private BluePrint bluePrint;

        private void OnDrawGizmos()
        {
            for (int i = 0; i < bluePrint.RoomData.Count; ++i)
            {
                var pos = bluePrint.GetPositionByRoomNumber(bluePrint.RoomData[i].RoomNumber);

                Gizmos.DrawWireCube(pos, Vector3.one);
                Handles.Label(pos, bluePrint.RoomData[i].RoomNumber.ToString());

                switch (bluePrint.RoomData[i].RoomType)
                {
                    case ERoomType.Boss:
                        Gizmos.DrawIcon(pos, "GizmoSprite_MinimapIcon_Boss");
                        break;
                    case ERoomType.Treasure:
                        Gizmos.DrawIcon(pos, "GizmoSprite_MinimapIcon_Treasure");
                        break;
                    case ERoomType.Shop:
                        Gizmos.DrawIcon(pos, "GizmoSprite_MinimapIcon_Shop");
                        break;
                    case ERoomType.Normal:
                        break;
                    default:
                        LogHelper.ShowDefaultCaseLog();
                        break;
                }                
            }
        }
    }
}