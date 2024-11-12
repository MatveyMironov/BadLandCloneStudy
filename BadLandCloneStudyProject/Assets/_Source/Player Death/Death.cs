using System;
using UnityEngine;

namespace Player
{
    public class Death : MonoBehaviour
    {
        public event Action OnDeath;

        public void InvokeDeath()
        {
            gameObject.SetActive(false);
            OnDeath?.Invoke();
        }
    }
}