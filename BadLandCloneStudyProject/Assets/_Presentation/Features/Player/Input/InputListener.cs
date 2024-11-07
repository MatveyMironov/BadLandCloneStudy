using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inputManager.InvokeUpwardFlight();
            }

            float horizontal = Input.GetAxis("Horizontal");
            inputManager.InvokeSidewayFlight(horizontal);
        }
    }
}