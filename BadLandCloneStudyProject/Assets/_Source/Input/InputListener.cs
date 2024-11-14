using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    public class InputListener
    {
        private InputManager _inputManager;

        public InputListener(InputManager inputManager)
        {
            _inputManager = inputManager;

            Initialize();
        }

        private PlayerControls _playerControls;

        private void Initialize()
        {
            _playerControls = new();

            _playerControls.MainActionMap.Ascend.performed += OnAscendInput;

            _playerControls.MainActionMap.Descend.started += OnDescendInput;
            _playerControls.MainActionMap.Descend.canceled += OnDescendInput;

            _playerControls.MainActionMap.FlySideways.started += OnSidewaysInput;
            _playerControls.MainActionMap.FlySideways.performed += OnSidewaysInput;
            _playerControls.MainActionMap.FlySideways.canceled += OnSidewaysInput;

            _playerControls.MainActionMap.Enable();
        }

        private void OnAscendInput(InputAction.CallbackContext callbackContext)
        {
            _inputManager.InvokeAscend();
        }

        private void OnDescendInput(InputAction.CallbackContext context)
        {
            bool shouldDescend = context.ReadValueAsButton();

            _inputManager.InvokeDescend(shouldDescend);
        }

        private void OnSidewaysInput(InputAction.CallbackContext callbackContext)
        {
            float direction = callbackContext.ReadValue<float>();
            _inputManager.InvokeSidewayFlight(direction);
        }
    }
}