namespace PlayerSystem
{
    public class MovementController
    {
        private PlayerMovement _playerMovement;

        public MovementController(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }

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