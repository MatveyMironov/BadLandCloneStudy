using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        [Space]
        [SerializeField] private float ascendForce;
        [SerializeField] private float maxAscendingSpeed;
        [SerializeField] private float ascendCooldown;

        [Space]
        [SerializeField] private float descendForce;
        [SerializeField] private float maxDescendingSpeed;

        [Space]
        [SerializeField] private float horizontalForce;
        [SerializeField] private float maxHorizontalSpeed;

        [Space]
        [SerializeField] private float maxFallingSpeed;

        [Space]
        [SerializeField] private float rotationSpeed;

        private Vector2 _combinedForce = Vector2.zero;

        private float _accendCooldownTimer = 0f;
        private bool _readyToAccend = true;

        private bool _isDescending;

        private bool _isTouchingSomething;
        private float _normalRotation = 0f;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _rigidbody.AddForce(_combinedForce, ForceMode2D.Force);

            if (!_readyToAccend)
            {
                CountAccendCooldown();
            }

            if (!_isTouchingSomething)
            {
                RotateFace();
            }

            ClampSpeed();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _isTouchingSomething = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            _isTouchingSomething = false;
        }

        public void Ascend()
        {
            if (!_readyToAccend) { return; }

            if (_rigidbody.velocity.y < 0)
            {
                Vector2 stopDescendVelocity = new(_rigidbody.velocity.x, 0);
                _rigidbody.velocity = stopDescendVelocity;
            }

            _rigidbody.AddForce(Vector2.up * ascendForce, ForceMode2D.Impulse);
            _readyToAccend = false;
        }

        public void StartDescend()
        {
            _isDescending = true;
            _combinedForce.y = -descendForce;
        }

        public void StopDescend()
        {
            _isDescending = false;
            _combinedForce.y = 0;
        }

        public void StartRightFlight()
        {
            _combinedForce.x = horizontalForce;
        }

        public void StartLeftFlight()
        {
            _combinedForce.x = -horizontalForce;
        }

        public void StopHorizontalFlight()
        {
            _combinedForce.x = 0;
        }

        private void ClampSpeed()
        {
            if (_rigidbody.velocity.y > maxAscendingSpeed)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, maxAscendingSpeed);
            }
            else
            {
                if (_isDescending)
                {
                    if (_rigidbody.velocity.y < -maxDescendingSpeed)
                    {
                        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -maxDescendingSpeed);
                    }
                }
                else
                {
                    if (_rigidbody.velocity.y < -maxFallingSpeed)
                    {
                        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -maxFallingSpeed);
                    }
                }
            }

            if (_rigidbody.velocity.x > maxHorizontalSpeed)
            {
                _rigidbody.velocity = new Vector2(maxHorizontalSpeed, _rigidbody.velocity.y);
            }
            else if (_rigidbody.velocity.x < -maxHorizontalSpeed)
            {
                _rigidbody.velocity = new Vector2(-maxHorizontalSpeed, _rigidbody.velocity.y);
            }
        }

        private void RotateFace()
        {
            if (_rigidbody.angularVelocity != 0)
            {
                _rigidbody.angularVelocity = 0;
            }

            _rigidbody.rotation = Mathf.MoveTowardsAngle(_rigidbody.rotation, _normalRotation, rotationSpeed * Time.deltaTime);
        }

        private void CountAccendCooldown()
        {
            _accendCooldownTimer += Time.deltaTime;
            if (_accendCooldownTimer >= ascendCooldown)
            {
                _accendCooldownTimer = 0;
                _readyToAccend = true;
            }
        }
    }
}