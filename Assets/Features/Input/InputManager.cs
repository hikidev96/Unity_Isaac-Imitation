using UnityEngine;
using UnityEngine.InputSystem;

namespace II
{
    public class InputManager : MonoBehaviour, Controls.IIsaacControlActions
    {
        private Controls controls;
        private Vector2 movementValue;

        public Vector2 MovementValue => movementValue;

        private void Awake()
        {
            controls = new Controls();            
        }

        private void Start()
        {
            SetCallbacks();
            EnableAllInput();
        }

        private void SetCallbacks()
        {
            controls.IsaacControl.SetCallbacks(this);
        }

        public void EnableAllInput()
        {
            controls.IsaacControl.Enable();
        }

        void Controls.IIsaacControlActions.OnHorizontalMove(InputAction.CallbackContext context)
        {
            movementValue = new Vector2(context.ReadValue<float>(), MovementValue.y);
        }

        void Controls.IIsaacControlActions.OnVerticalMove(InputAction.CallbackContext context)
        {
            movementValue = new Vector2(MovementValue.x, context.ReadValue<float>());
        }
    }
}