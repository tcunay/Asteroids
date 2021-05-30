using UnityEngine;

namespace ShapeCreators
{
    [RequireComponent(typeof(EdgeCollider2D))]
    public class ShapeCreatorWithEdgeCollider2D : ShapeCreator<EdgeCollider2D>
    {
        protected override void SetPointsInCollider(Vector2[] points, EdgeCollider2D collider2D)
        {
            collider2D.points = points;
        }
    }
}