using UnityEngine;

namespace II
{
    public class Isaac : MonoBehaviour
    {
        public static Isaac Instance;

        [SerializeField] private GameObject bombPrefab;

        private int coinCount;
        private int keyCount = 1;
        private int bombCount = 1;
        private int currentHeartCount = 6;
        private int maxHeartCount = 6;

        private void Awake()
        {
            Instance = this;
        }

        private void OnEnable()
        {
            Manager.Input.OnUseBombKeyPress.AddListener(UseBomb);
        }

        private void OnDisable()
        {
            Manager.Input.OnUseBombKeyPress.RemoveListener(UseBomb);
        }

        public void AddCoin(int amount)
        {
            coinCount += amount;
        }

        public void AddKey(int amount)
        {
            keyCount += amount;
        }

        public bool TryUseKey()
        {
            if (keyCount == 0) return false;

            keyCount -= 1;

            return true;
        }

        public void AddBomb(int amount)
        {
            bombCount += amount;
        }

        public bool TryAddHeart(int amount)
        {
            if (maxHeartCount == currentHeartCount) return false;

            currentHeartCount += amount;

            if (currentHeartCount > maxHeartCount)
            {
                currentHeartCount = maxHeartCount;
            }

            return true;
        }

        public void UseBomb()
        {
            if (bombCount == 0) return;

            bombCount -= 1;

            var bomb = Instantiate(bombPrefab, this.transform.position + new Vector3(0.0f, 0.3f, 0.0f), Quaternion.identity).GetComponent<Bomb>();
            bomb.Throw();
        }
    }
}