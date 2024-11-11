using UnityEngine;

namespace Player
{
    public class PlayerFollow : MonoBehaviour
    {
        private Transform _playerTransform;

        [SerializeField] private float yPosition;

        private void Update()
        {
            Follow();
        }

        public void Setup(Transform player)
        {
            _playerTransform = player;
        }

        private void Follow()
        {
            if (_playerTransform != null)
            {
                Vector3 targetPosition = new(_playerTransform.position.x, yPosition, -1);
                transform.position = targetPosition;
            }
        }
    }
}