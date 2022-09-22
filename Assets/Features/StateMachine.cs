using UnityEngine;

namespace II
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private State entryState;

        private State currentState;

        private void Start()
        {
            entryState.Enter();
            currentState = entryState;
        }

        private void Update()
        {
            currentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            currentState.PhyiscsUpdate();
        }

        public void ChangeStateTo(State toState)
        {
            entryState.Exit();
            toState.Enter();

            currentState = toState;
        }
    }
}