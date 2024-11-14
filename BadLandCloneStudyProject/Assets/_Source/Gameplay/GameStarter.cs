using InputSystem;
using LevelSystem;
using PlayerSystem;
using UnityEngine;

namespace Gameplay
{
    public class GameStarter
    {
        private StartMenu _startMenu;
        private InputListener _inputListener;
        private PlayerSpawner _playerSpawner;
        private LevelSwitcher _levelSwitcher;
        private Player _player;

        private bool _gameStarted;

        public GameStarter(StartMenu startMenu,
                           InputListener inputListener,
                           PlayerSpawner playerSpawner,
                           LevelSwitcher levelSwitcher,
                           Player player)
        {
            _startMenu = startMenu;
            _inputListener = inputListener;
            _playerSpawner = playerSpawner;
            _levelSwitcher = levelSwitcher;
            _player = player;

            Initialize();
        }

        private void Initialize()
        {
            _player.gameObject.SetActive(false);

            _levelSwitcher.CreateNextLevel();

            _startMenu.OnStartButtonClicked += StartGame;
            _startMenu.OpenMenu();

            _inputListener.DisableMainActionMap();
        }

        private void StartGame()
        {
            if (_gameStarted) { return; }
            _gameStarted = true;

            _startMenu.CloseMenu();

            _inputListener.EnableMainActionMap();

            _playerSpawner.SpawnPlayer();
        }
    }
}