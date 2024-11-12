using Size;
using UnityEngine;

namespace Player
{
    public class PlayerReferences : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SizeChanger _sizeChanger;

        public Rigidbody2D Rigidbody { get => _rigidbody; }
        public SizeChanger SizeChanger { get => _sizeChanger; }
    }
}