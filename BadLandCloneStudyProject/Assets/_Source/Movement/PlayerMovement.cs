using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        [Space]
        [SerializeField] private float ascendAcceleration;
        [SerializeField] private float maxAscendingSpeed;
        [SerializeField] private float ascendCooldown;

        [Space]
        [SerializeField] private float descendSpeed;
        [SerializeField] private float horizontalSpeed;

        [Space]
        [SerializeField] private float gravityAcceleration;
        [SerializeField] private float maxFallingSpeed;

        [Space]
        [SerializeField] private float rotationSpeed;

        private Vector2 _combinedVelocity = Vector2.zero;

        private float _accendCooldownTimer = 0f;
        private bool _readyToAccend = true;

        private bool _isTouchingSomething;
        private float _normalRotation = 0f;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _rigidbody.velocity = _combinedVelocity;

            ApplyGravity();

            if (!_readyToAccend)
            {
                CountAccendCooldown();
            }

            if (!_isTouchingSomething)
            {
                RotateFace();
            }
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

            if (_combinedVelocity.y < 0)
            {
                _combinedVelocity.y = 0;
            }

            if (_combinedVelocity.y < maxAscendingSpeed)
            {
                _combinedVelocity.y = Mathf.MoveTowards(_combinedVelocity.y, maxAscendingSpeed, ascendAcceleration);
                _readyToAccend = false;
            }
        }

        public void StartDescend()
        {
            _combinedVelocity.y = -descendSpeed;
        }

        public void StopDescend()
        {
            if (_combinedVelocity.y < -maxFallingSpeed)
            {
                _combinedVelocity.y = -maxFallingSpeed;
            }
        }

        public void FlyRight()
        {
            _combinedVelocity.x = horizontalSpeed;
        }

        public void FlyLeft()
        {
            _combinedVelocity.x = -horizontalSpeed;
        }

        public void StopSidewayFlight()
        {
            _combinedVelocity.x = 0;
        }

        private void RotateFace()
        {
            if (_rigidbody.angularVelocity != 0)
            {
                Debug.Log("Stop");
                _rigidbody.angularVelocity = 0;
            }


            _rigidbody.rotation = Mathf.MoveTowardsAngle(_rigidbody.rotation, _normalRotation, rotationSpeed * Time.deltaTime);
        }

        private void ApplyGravity()
        {
            if (_combinedVelocity.y > -maxFallingSpeed)
            {
                _combinedVelocity.y = Mathf.MoveTowards(_combinedVelocity.y, -maxFallingSpeed, gravityAcceleration * Time.deltaTime);
            }
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