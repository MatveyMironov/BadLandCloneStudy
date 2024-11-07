using Player;
using UnityEngine;

namespace InputSystem
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;

        public void InvokeUpwardFlight()
        {

        }

        public void InvokeSidewayFlight(float direction)
        {
            if (direction < 0)
            {
                playerMovement.FlyLeft();
            }
            else if (direction > 0)
            {
                playerMovement.FlyRight();
            }
            else
            {
                playerMovement.StopSidewayFlight();
            }
        }
    }
}