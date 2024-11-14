using Gameplay;
using InputSystem;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerFollow _camera;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private StartMenu _startMenu;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Player _player;

        private InputListener _inputListener;
        private InputManager _inputManager;
        private PlayerSpawner _playerSpawner;
        private PlayerRespawn _playerRespawn;
        private GameStarter _gameStarter;

        private void Start()
        {
            _camera.Setup(_player.transform);

            _inputManager = new(_playerMovement);
            _inputListener = new(_inputManager);
            _playerSpawner = new(_player, _playerSpawnPoint);
            _gameStarter = new(_startMenu, _inputManager, _playerSpawner);
            _playerRespawn = new(_player, _playerSpawner);
        }
    }
}