using PlayerSystem;
using UnityEngine;

namespace Gameplay
{
    public class PlayerSpawner
    {
        private Player _player;
        private Transform _spawnPoint;

        public PlayerSpawner(Player player, Transform spawnPoint)
        {
            _player = player;
            _spawnPoint = spawnPoint;
        }

        public void SpawnPlayer()
        {
            _player.SizeChanger.SetDefaultSize();

            _player.Rigidbody.velocity = Vector3.zero;
            _player.transform.position = _spawnPoint.position;
            _player.gameObject.SetActive(true);
        }
    }
}