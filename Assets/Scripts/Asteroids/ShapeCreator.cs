using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(PolygonCollider2D))]
public class ShapeCreator : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private PolygonCollider2D _polygonCollider2D;
    private int _sidesQuantity = 7;
    private float _minRadius = 0.5f;
    private float _maxRadius = 2;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Create(_sidesQuantity);
    }

    private void Create(int sidesQuantity)
    {
        Vector2[] anglePoints = new Vector2[sidesQuantity];
        _lineRenderer.positionCount = sidesQuantity + 1;

        float angle = 0;
        for (int i = 0; i < anglePoints.Length; i++)
        {
            float radius = GetRandomRadius();
            anglePoints[i].x = transform.position.x + (int)(Mathf.Round(Mathf.Cos(angle / 180 * Mathf.PI) * radius));
            anglePoints[i].y = transform.position.y - (int)(Mathf.Round(Mathf.Sin(angle / 180 * Mathf.PI) * radius));

            angle += 360 / sidesQuantity;

            _lineRenderer.SetPosition(i, new Vector3(anglePoints[i].x, anglePoints[i].y));
        }

        _lineRenderer.SetPosition(anglePoints.Length, _lineRenderer.GetPosition(0));

        SetPoligonColliderPoints(anglePoints);
    }

    private void SetPoligonColliderPoints(Vector2[] points)
    {
        _polygonCollider2D.points = points;
    }

    private Vector2 GetAnglePointInCircle(float angle)
    {

        return new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
    }

    private float GetRandomAngle(int sidesQuantity)
    {
        return Random.Range(0, 360 / sidesQuantity + 1);
    }

    private float GetRandomRadius()
    {
        return Random.Range(_minRadius, _maxRadius);
    }
}
