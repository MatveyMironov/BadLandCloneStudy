using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        [SerializeField] private float verticalSpeed;
        [SerializeField] private float horizontalSpeed;

        private Vector2 _combinedVelocity = Vector2.zero;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _rigidbody.velocity = _combinedVelocity;
        }

        public void FlyUp()
        {
            Vector2 upwardVelocity = Vector2.up * verticalSpeed;
            _rigidbody.velocity += upwardVelocity;
        }

        public void FlyRight()
        {
            _combinedVelocity.x = horizontalSpeed;
        }

        public void FlyLeft()
        {
            _combinedVelocity.x = -horizontalSpeed;
        }

        internal void StopSidewayFlight()
        {
            _combinedVelocity.x = 0;
        }
    }
}