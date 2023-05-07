using UnityEngine;

namespace UsefulPhysics
{
    [System.Serializable]
    public class Overlaps
    {
        [SerializeField] private float _radius = 1f;
        [SerializeField] private LayerMask _layer = default;

        public bool OverlapSphere(Vector3 position)
        {
            var pos = position;

            return Physics.OverlapSphere(pos, _radius, _layer).Length > 0;
        }
    }
}

