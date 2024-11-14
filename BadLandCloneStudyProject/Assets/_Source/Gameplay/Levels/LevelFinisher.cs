using PlayerSystem;
using System;
using UnityEngine;

namespace LevelSystem
{
    [RequireComponent(typeof(Collider2D))]
    public class LevelFinisher : MonoBehaviour
    {
        public event Action OnLevelFinished;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null)
            {
                if (collision.transform.TryGetComponent(out Player player))
                {
                    OnLevelFinished?.Invoke();
                }
            }
        }
    }
}