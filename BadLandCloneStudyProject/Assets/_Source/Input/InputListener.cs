using PlayerSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    public class InputListener
    {
        private MovementController _inputManager;

        private PlayerControls _playerControls;

        public InputListener(MovementController inputManager)
        {
            _inputManager = inputManager;

            Initialize();
        }

        public bool MainActionMapEnabled { get => _playerControls.MainActionMap.enabled; }

        private void Initialize()
        {
            _playerControls = new();

            _playerControls.MainActionMap.Ascend.performed += OnAscendInput;

            _playerControls.MainActionMap.Descend.started += OnDescendInput;
            _playerControls.MainActionMap.Descend.canceled += OnDescendInput;

            _playerControls.MainActionMap.FlySideways.started += OnSidewaysInput;
            _playerControls.MainActionMap.FlySideways.performed += OnSidewaysInput;
            _playerControls.MainActionMap.FlySideways.canceled += OnSidewaysInput;
        }

        public void EnableMainActionMap()
        {
            _playerControls.MainActionMap.Enable();
        }

        public void DisableMainActionMap()
        {

            _playerControls.MainActionMap.Disable();
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