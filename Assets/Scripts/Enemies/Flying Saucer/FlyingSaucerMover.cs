using UnityEngine;
using Players;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FlyingSaucerMover : MonoBehaviour
    {
        [SerializeField] private float _speedForce;

        private Player _player;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _player = FindObjectOfType<Player>();
        }

        private void FixedUpdate()
        {
            TryToFollow();
        }

        private void TryToFollow()
        {
            if (_player != null)
                ToFollow(_player.transform);
        }

        private void ToFollow(Transform target)
        {
            Vector2 direction = GetFollowDirection(target);

            _rigidbody.AddForce(direction.normalized * _speedForce * Time.fixedDeltaTime);
        }

        private Vector2 GetFollowDirection(Transform target)
        {
            return (target.position - transform.position);
        }
    }
}
