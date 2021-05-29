using Enemies;
using UnityEngine;

namespace Weapons.Shells
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour, ICharge, IMultiply
    {
        [SerializeField] private float _speedForce;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            Destroy(gameObject, 5);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IEnemy enemy))
                enemy.Die();
            TryMultiply();
            Destroy(gameObject);
        }

        public void Shot(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _speedForce, ForceMode2D.Impulse);
        }

        public void TryMultiply()
        {
            if (TryGetComponent(out Delimiter delimiter))
                delimiter.Multiply();
        }
    }
}
