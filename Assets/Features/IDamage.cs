using UnityEngine;

namespace II
{    
    public enum EDamageType
    {
        Tear,
        Bomb,
    }

    public interface IDamage
    {
        public void Damage(float damage, EDamageType damageType);
    }
}