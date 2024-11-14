using Gameplay;
using InputSystem;
using LevelSystem;
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

        [Header("Levels")]
        [SerializeField] private Transform levelRoute;
        [SerializeField] private LevelConstructionConfigurationSO levelConstructionConfiguration;
        [SerializeField] private LevelFinisher levelFinisher;

        private void Start()
        {
            _camera.Setup(_player.transform);

            InputManager inputManager = new(_playerMovement);
            InputListener inputListener = new(inputManager);
            PlayerSpawner playerSpawner = new(_player, _playerSpawnPoint);
            PlayerRespawn playerRespawn = new(_player, playerSpawner);
            LevelSwitcher levelSwitcher = new(levelRoute, levelConstructionConfiguration, levelFinisher.transform);
            LevelSwitchManager levelSwitchManager = new(levelFinisher, levelSwitcher, playerSpawner);
            GameStarter gameStarter = new(_startMenu, inputManager, playerSpawner, levelSwitcher);
        }
    }
}