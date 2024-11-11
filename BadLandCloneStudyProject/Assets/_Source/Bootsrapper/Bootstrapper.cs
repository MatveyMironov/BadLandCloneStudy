using Player;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerFollow _camera;
        [SerializeField] private Transform _playerTransform;

        private void Awake()
        {
            _camera.Setup(_playerTransform);
        }
    }
}