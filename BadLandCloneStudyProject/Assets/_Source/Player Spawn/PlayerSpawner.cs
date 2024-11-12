using UnityEngine;

namespace PlayerSpawn
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _playerRigidbody;

        [SerializeField] private Transform _spawnPoint;

        [ContextMenu("Spawn Player")]
        public void SpawnPlayer()
        {
            _playerRigidbody.velocity = Vector3.zero;
            _playerRigidbody.transform.position = _spawnPoint.position;
            _playerRigidbody.gameObject.SetActive(true);
        }
    }
}