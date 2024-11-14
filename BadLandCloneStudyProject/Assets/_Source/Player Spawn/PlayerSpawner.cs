using Player;
using UnityEngine;

namespace Gameplay
{
    public class PlayerSpawner
    {
        private PlayerReferences _player;
        private Transform _spawnPoint;

        public PlayerSpawner(PlayerReferences player, Transform spawnPoint)
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