using UnityEngine;

namespace ShapeCreators
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public class ShapeCreatorWithPoligonCollider2D : ShapeCreator<PolygonCollider2D>
    {
        protected override void SetPointsInCollider(Vector2[] points, PolygonCollider2D collider2D)
        {
            collider2D.points = points;
        }
    }
}
