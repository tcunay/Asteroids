using UnityEngine;

namespace Weapons.Shells
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour, ICharge
    {
        [SerializeField] private float _speedForce;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject);
        }

        public void Shot(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _speedForce, ForceMode2D.Impulse);
        }
    }
}
