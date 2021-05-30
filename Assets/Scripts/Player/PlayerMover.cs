using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speedForce;
        [SerializeField] private float _rotateSpeed;

        private Rigidbody2D _rigidbody;
        private float _tourque;
        private float _engine;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            //SetEngine();
            //SetTourqe();
        }

        private void FixedUpdate()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            _rigidbody.AddForce(transform.up * _engine * _speedForce * Time.fixedDeltaTime, ForceMode2D.Force);
        }

        public void SetEngine(bool isEngine)
        {
            if (isEngine)
                _engine = 1;
            else
                _engine = 0;
        }

        private void Rotate()
        {
            _rigidbody.AddTorque(_tourque * _rotateSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        }

        public void SetTourqe(float tourque)
        {
            _tourque = tourque;
        }
    }
}
