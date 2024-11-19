using UnityEngine;

namespace PlayerSystem
{
    public class FloorChecker
    {
        private Transform _self;
        private LayerMask _layers;

        public FloorChecker(Transform self, LayerMask layers)
        {
            _self = self;
            _layers = layers;
        }

        public bool Check(float desiredDistance)
        {
            RaycastHit2D hit = Physics2D.Raycast(_self.position, -_self.up, desiredDistance, _layers);

            if (hit.collider != null)
            {
                return true;
            }

            return false;
        }
    }
}