using UnityEngine;

namespace Players
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speedForce;
        [SerializeField] private float _rotateSpeed;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move(GetEngine());
            Rotate(GetTourqe());
        }

        private void Move(int engine)
        {
            _rigidbody.AddForce(transform.up * engine * _speedForce * Time.fixedDeltaTime, ForceMode2D.Force);
        }

        private int GetEngine()
        {
            if (Input.GetKey(KeyCode.W))
                return 1;
            else
                return 0;
        }

        private void Rotate(float tourqe)
        {
            _rigidbody.AddTorque(tourqe * _rotateSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        }

        private float GetTourqe()
        {
            return -Input.GetAxis("Horizontal");
        }
    }
}
