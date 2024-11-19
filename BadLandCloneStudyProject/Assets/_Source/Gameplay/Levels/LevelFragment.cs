using UnityEngine;

namespace LevelSystem
{
    public class LevelFragment : MonoBehaviour
    {
        [SerializeField] private Transform fragmentEnd;

        public Transform FragmentEnd { get => fragmentEnd; }
    }
}