using InputSystem;
using LevelSystem;

namespace Gameplay
{
    public class GameStarter
    {
        private StartMenu _startMenu;
        private InputManager _inputManager;
        private PlayerSpawner _playerSpawner;
        private LevelSwitcher _levelSwitcher;

        private bool _gameStarted;

        public GameStarter(StartMenu startMenu, InputManager inputManager, PlayerSpawner playerSpawner, LevelSwitcher levelSwitcher)
        {
            _startMenu = startMenu;
            _inputManager = inputManager;
            _playerSpawner = playerSpawner;
            _levelSwitcher = levelSwitcher;

            Initialize();
        }

        private void Initialize()
        {
            _levelSwitcher.CreateNextLevel();

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