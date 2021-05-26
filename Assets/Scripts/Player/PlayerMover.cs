using UnityEngine;

namespace Player
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

        private void Update()
        {
            Rotate(GetRotateDirection());
        }

        private void FixedUpdate()
        {
            Move(GetEngine());
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

        private void Rotate(Vector3 direction)
        {
            transform.Rotate(direction * _rotateSpeed * Time.deltaTime, Space.World);
        }

        private Vector3 GetRotateDirection()
        {
            float direction = Input.GetAxis("Horizontal");
            return new Vector3(0, 0, -direction);
        }
    }
}
