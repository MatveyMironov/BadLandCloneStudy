using UnityEngine;

namespace Player
{
    public class PlayerFollow : MonoBehaviour
    {
        [SerializeField] private Transform _player;

        [SerializeField] private float yPosition;

        private void Update()
        {
            Follow();
        }

        private void Follow()
        {
            if (_player != null)
            {
                Vector3 targetPosition = new(_player.position.x, yPosition, -1);
                transform.position = targetPosition;
            }
        }
    }
}