using UnityEngine;
using UnityEngine.Events;
using Animancer;
using Sirenix.OdinInspector;

namespace II
{
    public class Monster : MonoBehaviour, IDamage
    {
        [SerializeField] protected AnimancerComponent animancer;
        [SerializeField] protected float maxHp;
        [SerializeField] protected StateMachine sm;

        protected float currentHp;
        protected bool isDead = false;
        protected Room room;
        protected UnityEvent onDie = new UnityEvent();
        protected Rigidbody2D rb2d;

        protected virtual void Awake()
        {
            currentHp = maxHp;
            rb2d = GetComponent<Rigidbody2D>();
        }

        public static Monster Create(GameObject prefab, Vector2 position, Room room)
        {
            var newMonster = Instantiate(prefab, position, Quaternion.identity).GetComponent<Monster>();
            newMonster.SetRoom(room);

            return newMonster;
        }

        [Button("Damage"), TitleGroup("TEST")]
        public virtual void Damage(float damage, EDamageType damageType)
        {
            if (isDead == true)
            {
                return;
            }

            currentHp -= damage;

            if (currentHp <= 0.0f)
            {
                onDie?.Invoke();
                isDead = true;
            }
        }

        public void SetRoom(Room room)
        {
            this.room = room;
        }        

        protected virtual void OnCollisionStay2D(Collision2D collision)
        {
            var isaac = collision.gameObject.GetComponent<Isaac>();

            if (isaac != null)
            {
                isaac.Damage(1.0f, EDamageType.Contact);
            }
        }
    }
}