using UnityEngine;

namespace UsefulPhysics
{
    [System.Serializable]
    public class Overlaps
    {
        [SerializeField] private Vector3 _overlapOffset = Vector3.zero;
        [SerializeField] private float _radius = 1f;
        [SerializeField] private LayerMask _layer = default;

        private int _previousFrameCount = default;
        private Collider[] _cachedColliders = default;

        public Collider[] GetColliders(Transform origin)
        {
            if (_previousFrameCount != Time.frameCount)
            {
                _previousFrameCount = Time.frameCount;
                var offset = _overlapOffset;
                var dir = origin.rotation * offset;
                return _cachedColliders = Physics.OverlapSphere(origin.position + dir, _radius, _layer);
            }

            return _cachedColliders;
        }

        public bool IsHitBySphere(Transform origin)
        {
            var colls = GetColliders(origin);

            return colls.Length > 0;
        }

#if UNITY_EDITOR
        [Header("GizmoŠÖ˜A")]
        [SerializeField]
        private bool _isDrawGizmo = true;
        [SerializeField]
        private Color _hitColor = Color.red;
        [SerializeField]
        private Color _noHitColor = Color.blue;

        public void OnDrawGizmos(Transform origin)
        {
            if (_isDrawGizmo)
            {
                var offset = _overlapOffset;
                var dir = origin.rotation * offset;

                if (IsHitBySphere(origin))
                {
                    Gizmos.color = _hitColor;
                }
                else
                {
                    Gizmos.color = _noHitColor;
                }
                Gizmos.DrawSphere(origin.position + dir, _radius);
            }
        }
#endif
    }
}

