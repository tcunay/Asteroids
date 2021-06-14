using UnityEngine;
using UnityEngine.Events;
using ShapeCreators;

public class Zone : MonoBehaviour
{
    private ShapeCreatorWithEdgeCollider2D _shapeCreator;
    private Vector3[] _boundaryPoints;

    public Transform Center => transform;

    public event UnityAction<Vector3[]> Created;

    private void Awake()
    {
        _shapeCreator = GetComponent<ShapeCreatorWithEdgeCollider2D>();
    }

    private void OnEnable()
    {
        _shapeCreator.Created += SetBoudaryPoints;
    }

    private void OnDisable()
    {
        _shapeCreator.Created -= SetBoudaryPoints;
    }

    private void SetBoudaryPoints(Vector3[] points)
    {
        _boundaryPoints = points;
        Created?.Invoke(_boundaryPoints);
    }
}
