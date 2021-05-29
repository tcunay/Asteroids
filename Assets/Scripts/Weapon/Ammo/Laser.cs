using UnityEngine;
using Enemies;

namespace Weapons.Ammunition
{
    [RequireComponent(typeof(LineRenderer))]
    public class Laser : Ammo
    {
        [SerializeField] private float _distanceLineRaender;

        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            Shot();
        }

        protected override void Shot()
        {
            CastRay(transform.position, transform.up * _distanceLineRaender);
            RenderLine(transform.position, transform.up * _distanceLineRaender);
        }

        private void CastRay(Vector3 startPosition, Vector3 endPosition)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(startPosition, endPosition);
            foreach (var hit in hits)
            {
                if (hit.collider.TryGetComponent(out Enemy enemy))
                {
                    Destroy(enemy.gameObject);
                    ReportKilled();
                }
            }

#if UNITY_EDITOR
            Debug.DrawRay(transform.position, transform.up * _distanceLineRaender);
#endif
        }

        private void RenderLine(Vector3 startPosition, Vector3 endPosition)
        {
            _lineRenderer.SetPosition(0, startPosition);
            _lineRenderer.SetPosition(1, endPosition);
        }
    }
}
