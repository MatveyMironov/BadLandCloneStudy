using InputSystem;

namespace Gameplay
{
    public class GameStarter
    {
        private StartMenu _startMenu;
        private InputManager _inputManager;
        private PlayerSpawner _playerSpawner;

        private bool _gameStarted;

        public GameStarter(StartMenu startMenu, InputManager inputManager, PlayerSpawner playerSpawner)
        {
            _startMenu = startMenu;
            _inputManager = inputManager;
            _playerSpawner = playerSpawner;

            Initialize();
        }

        private void Initialize()
        {
            _startMenu.OnStartButtonClicked += StartGame;

            _startMenu.OpenMenu();

            _inputManager.InputEnabled = false;
        }

        private void StartGame()
        {
            if (_gameStarted) { return; }
            _gameStarted = true;

            _startMenu.CloseMenu();

            _inputManager.InputEnabled = true;

            _playerSpawner.SpawnPlayer();
        }
    }
}