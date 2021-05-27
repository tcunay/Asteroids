using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Weapons.Shells
{
    [RequireComponent(typeof(LineRenderer))]
    public class Laser : MonoBehaviour, ICharge
    {
        [SerializeField] private float _distanceToRay;

        private LineRenderer _lineRenderer;
        private float _lifeTime = 0.5f;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        public void Shot(Vector3 direction)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction);
            DrawRay(transform.localPosition, direction.normalized * _distanceToRay);

            Destroy(gameObject, _lifeTime);
        }

        private void DrawRay(Vector3 startPosition, Vector3 endPosition)
        {
            _lineRenderer.SetPosition(0, startPosition);
            _lineRenderer.SetPosition(1, endPosition);
        }
    }
}
