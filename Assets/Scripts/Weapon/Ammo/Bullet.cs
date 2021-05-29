using Enemies;
using UnityEngine;

namespace Weapons.Ammunition
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : Ammo, IMultiply
    {
        [SerializeField] private float _speedForce;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        protected override void Start()
        {
            base.Start();
            Shot();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.Die();
                ReportKilled();
            }

            TryMultiply();
            Destroy(gameObject);
        }

        protected override void Shot()
        {
            _rigidbody.AddForce(transform.up * _speedForce, ForceMode2D.Impulse);
        }

        public void TryMultiply()
        {
            if (TryGetComponent(out Delimiter delimiter))
                delimiter.Multiply();
        }
    }
}
