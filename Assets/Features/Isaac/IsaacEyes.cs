using System.Collections;
using UnityEngine;

namespace II
{
    public enum EEYe
    {
        LeftEye,
        RightEye
    }

    public class IsaacEyes : MonoBehaviour
    {
        [SerializeField] private Transform leftEyeSpotWhenHorizontal;
        [SerializeField] private Transform rightEyeSpotWhenHorizontal;
        [SerializeField] private Transform leftEyeSpotWhenVertical;
        [SerializeField] private Transform rightEyeSpotWhenVertical;
        [SerializeField] private GameObject tearPrefab;
        [SerializeField] private float fireRate;

        private EEYe eyeToFire;
        private bool isPossibleToFire = true;

        private void Update()
        {
            TryFireTear();
        }

        public bool TryFireTear()
        {
            if (isPossibleToFire == false) return false;
            if (Manager.Input.FireValue == Vector2.zero) return false;
            
            var newTearObj = Instantiate(tearPrefab, GetPosToFireTear(), Quaternion.identity);
            newTearObj.transform.right = Manager.Input.FireValue;
            SwapEyeToFire();
            StartCoroutine(WaitForReadyToFire());

            return true;
        }

        private Vector2 GetPosToFireTear()
        {
            if (Manager.Input.FireValue.x != 0.0f)
            {
                if (eyeToFire == EEYe.LeftEye) return leftEyeSpotWhenHorizontal.position;
                if (eyeToFire == EEYe.RightEye) return rightEyeSpotWhenHorizontal.position;
            }

            if (Manager.Input.FireValue.y != 0.0f)
            {
                if (eyeToFire == EEYe.LeftEye) return leftEyeSpotWhenVertical.position;
                if (eyeToFire == EEYe.RightEye) return rightEyeSpotWhenVertical.position;
            }

            return leftEyeSpotWhenVertical.position;
        }

        //private Vector2 GetDirToFire()
        //{
        //    if (Manager.Input.FireValue)
        //}

        private void SwapEyeToFire()
        {
            if (eyeToFire == EEYe.RightEye) eyeToFire = EEYe.LeftEye;
            else eyeToFire = EEYe.RightEye;
        }

        IEnumerator WaitForReadyToFire()
        {
            isPossibleToFire = false;
            yield return new WaitForSeconds(fireRate);
            isPossibleToFire = true;
        }
    }
}
