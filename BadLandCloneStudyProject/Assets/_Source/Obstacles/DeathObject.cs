using Player;
using UnityEngine;

namespace Obstacles
{
    public class DeathObject : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision != null)
            {
                if (collision.transform.TryGetComponent(out Death death))
                {
                    death.InvokeDeath();
                }
            }
        }
    }
}