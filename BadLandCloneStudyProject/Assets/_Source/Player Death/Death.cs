using System;
using UnityEngine;

namespace Player
{
    public class Death : MonoBehaviour
    {
        public event Action OnDeath;

        public void InvokeDeath()
        {
            Debug.Log("Death");
            OnDeath?.Invoke();
        }
    }
}