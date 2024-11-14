using Size;
using System;
using UnityEngine;

namespace PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour, IKillable
    {
        private Rigidbody2D _rigidbody;

        [SerializeField] private SizeChanger _sizeChanger;

        public Rigidbody2D Rigidbody { get => _rigidbody; }
        public SizeChanger SizeChanger { get => _sizeChanger; }


        public event Action OnDeath;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Kill()
        {
            gameObject.SetActive(false);
            OnDeath?.Invoke();
        }
    }
}