using Player;
using UnityEngine;

namespace Gameplay
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerReferences _player;

        [SerializeField] private Transform _spawnPoint;

        [ContextMenu("Spawn Player")]
        public void SpawnPlayer()
        {
            _player.SizeChanger.SetDefaultSize();

            _player.Rigidbody.velocity = Vector3.zero;
            _player.transform.position = _spawnPoint.position;
            _player.gameObject.SetActive(true);
        }
    }
}