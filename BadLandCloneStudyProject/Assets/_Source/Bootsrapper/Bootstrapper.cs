using Gameplay;
using InputSystem;
using Player;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerFollow _camera;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private Death _playerDeath;
        [SerializeField] private StartMenu _startMenu;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private PlayerReferences _playerReferences;

        private InputListener _inputListener;
        private InputManager _inputManager;
        private PlayerSpawner _playerSpawner;
        private PlayerRespawn _playerRespawn;
        private GameStarter _gameStarter;

        private void Awake()
        {
            _camera.Setup(_playerTransform);

            _inputManager = new(_playerMovement);
            _inputListener = new(_inputManager);
            _playerSpawner = new(_playerReferences, _playerSpawnPoint);
            _gameStarter = new(_startMenu, _inputManager, _playerSpawner);
            _playerRespawn = new(_playerDeath, _playerSpawner);
        }
    }
}