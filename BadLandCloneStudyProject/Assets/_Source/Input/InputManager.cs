using PlayerSystem;

namespace InputSystem
{
    public class InputManager
    {
        private PlayerMovement _playerMovement;

        public InputManager(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }

        public bool InputEnabled { get; set; }

        public void InvokeAscend()
        {
            _playerMovement.Ascend();
        }

        public void InvokeDescend(bool shouldDescend)
        {
            if (shouldDescend)
            {
                _playerMovement.StartDescend();
            }
            else
            {
                _playerMovement.StopDescend();
            }
        }

        public void InvokeSidewayFlight(float direction)
        {
            if (direction < 0)
            {
                _playerMovement.StartLeftFlight();
            }
            else if (direction > 0)
            {
                _playerMovement.StartRightFlight();
            }
            else
            {
                _playerMovement.StopHorizontalFlight();
            }
        }
    }
}