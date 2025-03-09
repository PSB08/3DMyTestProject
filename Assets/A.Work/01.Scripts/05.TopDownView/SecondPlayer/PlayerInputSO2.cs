using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDownView.SecondPlayer
{
    [CreateAssetMenu(fileName = "PlayerInput", menuName = "SO/PlayerInput2", order = 1)]
    public class PlayerInputSO2 : ScriptableObject, Controls2.IPlayerActions
    {
        public event Action<Vector2> OnMovementChange;
        public event Action OnAttackPressed;
        public event Action OnJumpPressed;
        public event Action<bool> OnRunPressed;

        private Controls2 _controls;

        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new Controls2();
                _controls.Player.SetCallbacks(this);
            }
            _controls.Player.Enable();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();
            OnMovementChange?.Invoke(input);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
                OnJumpPressed?.Invoke();
        }

        public void OnSpint(InputAction.CallbackContext context)
        {
            if (context.started)
                OnRunPressed?.Invoke(true);
            if (context.canceled)
                OnRunPressed?.Invoke(false);
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
                OnAttackPressed?.Invoke();
        }



    }
}