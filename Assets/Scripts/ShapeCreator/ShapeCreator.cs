using UnityEngine;
using UnityEngine.Events;


namespace ShapeCreators
{
    [RequireComponent(typeof(LineRenderer))]
    public abstract class ShapeCreator<T> : MonoBehaviour
    {
        [SerializeField] private float _minRadius = 0.7f;
        [SerializeField] private float _maxRadius = 2f;
        [SerializeField] private int _sidesQuantity = 6;

        private T _collider2D;
        private LineRenderer _lineRenderer;
        private Vector3[] _angleClosedPoints;

        public event UnityAction<Vector3[]> Creating;

        private void Awake()
        {
            _collider2D = GetComponent<T>();
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void Start()
        {
            Create();
        }

        protected abstract void SetPointsInCollider(Vector2[] points, T collider2D);

        public void Create()
        {
            _lineRenderer.positionCount = _sidesQuantity + 1;

            _angleClosedPoints = CalculatePoints();

            SetPointsInCollider(ConvertToVector2DArray(_angleClosedPoints), _collider2D);
            _lineRenderer.SetPositions(_angleClosedPoints);

            Creating?.Invoke(_angleClosedPoints);
        }

        private Vector3[] CalculatePoints()
        {
            Vector3[] anglePoints = new Vector3[_sidesQuantity];

            float angle = 0;
            for (int i = 0; i < anglePoints.Length; i++)
            {
                float radius = GetRandomRadius();
                anglePoints[i].x = -(Mathf.Cos(angle / 180 * Mathf.PI) * radius);
                anglePoints[i].y = +(Mathf.Sin(angle / 180 * Mathf.PI) * radius);

                angle += CalculateOneAngle(_sidesQuantity);
            }

            Vector3[] angleClosedPoints = new Vector3[anglePoints.Length + 1];
            for (int i = 0; i < angleClosedPoints.Length; i++)
            {
                if (i == anglePoints.Length)
                {
                    angleClosedPoints[i] = anglePoints[0];
                    break;
                }
                angleClosedPoints[i] = anglePoints[i];
            }

            return angleClosedPoints;
        }

        private float CalculateOneAngle(int sidesQuantity)
        {
            return 360 / sidesQuantity;
        }

        private Vector2[] ConvertToVector2DArray(Vector3[] points)
        {
            Vector2[] points2D = new Vector2[points.Length];

            for (int i = 0; i < points2D.Length; i++)
            {
                points2D[i].x = points[i].x;
                points2D[i].y = points[i].y;
            }

            return points2D;
        }

        private float GetRandomRadius()
        {
            return Random.Range(_minRadius, _maxRadius);
        }
    }
}