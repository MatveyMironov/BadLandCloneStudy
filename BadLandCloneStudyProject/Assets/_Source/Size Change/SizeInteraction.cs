using UnityEngine;

namespace Size
{
    public class SizeInteraction : MonoBehaviour
    {
        [SerializeField] private bool decreaseSize;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null)
            {
                if (collision.transform.TryGetComponent(out SizeChanger sizeChanger))
                {
                    bool successful;

                    if (decreaseSize)
                    {
                        sizeChanger.DecreaseSize(out successful);
                    }
                    else
                    {
                        sizeChanger.EncreaseSize(out successful);
                    }

                    if (successful)
                    {
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}