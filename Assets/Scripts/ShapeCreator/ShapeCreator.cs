using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public abstract class ShapeCreator<T> : MonoBehaviour
{
    [SerializeField] private float _minRadius = 0.7f;
    [SerializeField] private float _maxRadius = 2f;
    [SerializeField] private int _sidesQuantity = 6;

    private T _collider2D;
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _collider2D = GetComponent<T>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        Create();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Create();
    }

    protected abstract void SetPointsInCollider(Vector2[] points, T collider2D);

    public void Create()
    {
        _lineRenderer.positionCount = _sidesQuantity + 1;

        Vector3[] angleClosedPoints = CalculatePoints();

        SetPointsInCollider(ConvertToVector2DArray(angleClosedPoints), _collider2D);
        _lineRenderer.SetPositions(angleClosedPoints);
    }

    private Vector3[] CalculatePoints()
    {
        Vector3[] anglePoints = new Vector3[_sidesQuantity];

        float angle = 0;
        for (int i = 0; i < anglePoints.Length; i++)
        {
            float radius = GetRandomRadius();
            anglePoints[i].x = -(int)Mathf.Round(Mathf.Cos(angle / 180 * Mathf.PI) * radius);
            anglePoints[i].y = (int)Mathf.Round(Mathf.Sin(angle / 180 * Mathf.PI) * radius);

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
        Vector2[] edgePoints = new Vector2[points.Length];

        for (int i = 0; i < edgePoints.Length; i++)
        {
            edgePoints[i].x = points[i].x;
            edgePoints[i].y = points[i].y;
        }

        return edgePoints;
    }

    private float GetRandomRadius()
    {
        return Random.Range(_minRadius, _maxRadius);
    }

    public void SetScale(float factor)
    {
        _minRadius *= factor;
        _maxRadius *= factor;
    }
}
