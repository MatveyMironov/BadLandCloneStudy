using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;

        private PlayerControls _playerControls;

        private void Awake()
        {
            _playerControls = new();

            _playerControls.MainActionMap.Ascend.performed += OnAscendInput;

            _playerControls.MainActionMap.Descend.started += OnDescendInput;
            _playerControls.MainActionMap.Descend.canceled += OnDescendInput;

            _playerControls.MainActionMap.FlySideways.started += OnSidewaysInput;
            _playerControls.MainActionMap.FlySideways.performed += OnSidewaysInput;
            _playerControls.MainActionMap.FlySideways.canceled += OnSidewaysInput;
        }

        private void OnEnable()
        {
            _playerControls.MainActionMap.Enable();
        }

        private void OnDisable()
        {
            _playerControls.MainActionMap.Disable();
        }

        private void OnAscendInput(InputAction.CallbackContext callbackContext)
        {
            inputManager.InvokeAscend();
        }

        private void OnDescendInput(InputAction.CallbackContext context)
        {
            bool shouldDescend = context.ReadValueAsButton();

            inputManager.InvokeDescend(shouldDescend);
        }

        private void OnSidewaysInput(InputAction.CallbackContext callbackContext)
        {
            float direction = callbackContext.ReadValue<float>();
            inputManager.InvokeSidewayFlight(direction);
        }
    }
}