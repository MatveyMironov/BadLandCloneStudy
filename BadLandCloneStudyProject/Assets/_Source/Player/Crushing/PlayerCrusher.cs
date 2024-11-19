using UnityEngine;

namespace PlayerSystem
{
    public class PlayerCrusher : MonoBehaviour
    {
        [SerializeField] private LayerMask contactLayers;

        private CircleCollider2D _collider;
        private Player _player;

        private FloorChecker _floorChecker;
        private CeilingChecker _ceilingChecker;

        private void Awake()
        {
            _collider = GetComponent<CircleCollider2D>();
            _player = GetComponent<Player>();

            _floorChecker = new(transform, contactLayers);
            _ceilingChecker = new(transform, contactLayers);
        }

        private void Update()
        {
            float desiredDistance = _collider.radius - 0.05f;

            if (_floorChecker.Check(desiredDistance) && _ceilingChecker.Check(desiredDistance))
            {
                _player.Kill();
            }
        }
    }
}