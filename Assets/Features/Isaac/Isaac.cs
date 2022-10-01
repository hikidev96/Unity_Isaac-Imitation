using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace II
{
    public class Isaac : MonoBehaviour, IDamage
    {
        public static Isaac Instance;

        [SerializeField] private GameObject bombPrefab;

        private int coinCount = 10;
        private int keyCount = 1;
        private int bombCount = 1;
        private int currentHeartCount = 6;
        private int maxHeartCount = 6;
        private UnityEvent<int> onHeartRecover = new UnityEvent<int>();
        private UnityEvent onMaxHeartAdd = new UnityEvent();
        private UnityEvent onHeartDamage = new UnityEvent();

        public int CoinCount => coinCount;
        public int KeyCount => keyCount;
        public int BombCount => bombCount;
        public int CurrentHeartCount => currentHeartCount;
        public int MaxHeartCount => maxHeartCount;
        public UnityEvent<int> OnHeartRecover => onHeartRecover;
        public UnityEvent OnHeartAdd => onMaxHeartAdd;
        public UnityEvent OnHeartDamage => onHeartDamage; 

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

        public bool TryUseCoin(int amount)
        {
            if (coinCount < amount) return false;

            coinCount -= amount;

            return true;
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

        [Button]
        public void AddMaxHeart()
        {
            maxHeartCount += 2;

            onMaxHeartAdd.Invoke();
        }

        [Button]
        void IDamage.Damage(float damage, EDamageType damageType)
        {
            currentHeartCount -= 1;

            if (currentHeartCount < 0) // Isaac Die!
            {
                currentHeartCount = 0;
            }

            onHeartDamage.Invoke();
        }

        [Button]
        public bool TryRecoverHeart(int amount)
        {
            if (maxHeartCount == currentHeartCount) return false;

            currentHeartCount += amount;

            if (currentHeartCount > maxHeartCount)
            {
                currentHeartCount = maxHeartCount;
            }

            onHeartRecover.Invoke(amount);

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