using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SizeChanger : MonoBehaviour
    {
        [SerializeField] private Size[] sizes;
        [SerializeField] private int defaultSizeIndex;

        private Vector3 _axisRatio;

        private int _currentSizeIndex;
        private Rigidbody2D _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _axisRatio = _rigidBody.transform.localScale;

            if (defaultSizeIndex >= sizes.Length || defaultSizeIndex < 0)
            {
                _currentSizeIndex = 0;
            }
            else
            {
                _currentSizeIndex = defaultSizeIndex;
            }

            if (sizes.Length <= 0)
            {
                sizes = new Size[1];
                sizes[0] = new Size(1, _rigidBody.mass);
            }

            ChangeSize(sizes[_currentSizeIndex]);
        }

        private void ChangeSize(Size sizeBlueprint)
        {
            _rigidBody.mass = sizeBlueprint.Mass;
            _rigidBody.transform.localScale = _axisRatio * sizeBlueprint.Scale;
        }

        [ContextMenu("Encrease Size")]
        public void EncreaseSize()
        {
            if (_currentSizeIndex >= sizes.Length) { return; }

            _currentSizeIndex++;
            ChangeSize(sizes[_currentSizeIndex]);
        }

        [ContextMenu("Decrease Size")]
        public void DecreaseSize()
        {
            if (_currentSizeIndex <= 0) { return; }

            _currentSizeIndex--;
            ChangeSize(sizes[_currentSizeIndex]);
        }

        [Serializable]
        private class Size
        {
            public Size(float scale, float mass)
            {
                Scale = scale;
                Mass = mass;
            }

            [field: SerializeField] public float Scale { get; private set; }
            [field: SerializeField] public float Mass { get; private set; }
        }
    }
}