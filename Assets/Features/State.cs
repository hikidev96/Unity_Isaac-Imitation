using UnityEngine;

namespace II
{
    public abstract class State : MonoBehaviour
    {
        public abstract void Enter();
        public abstract void LogicUpdate();
        public abstract void PhyiscsUpdate();
        public abstract void Exit();
    }
}
