using UnityEngine;

namespace Obstacles
{
    public class Wheel : MonoBehaviour
    {
        [Tooltip("Degrees per second")]
        [SerializeField] private float rotationSpeed;

        void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            Vector3 currentRotationEuler = transform.rotation.eulerAngles;
            Quaternion targetRotation = Quaternion.Euler(0, 0, currentRotationEuler.z + rotationSpeed * Time.deltaTime);
            transform.rotation = targetRotation;
        }
    }
}