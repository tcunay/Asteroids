using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AsteroidMover : MonoBehaviour
{
    [SerializeField] private float _speedForce;
    [SerializeField] private float _startTorque;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        MoveNext(GetRandomDirection());
        StartRotate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MoveNext(GetContactDirection(collision));
    }

    private Vector2 GetContactDirection(Collision2D collision)
    {
        Vector2 direction = Vector2.zero;
        foreach (var contact in collision.contacts)
        {
            direction += contact.normal.normalized;
        }
        return direction.normalized;
    }

    private Vector2 GetRandomDirection()
    {
        return Random.insideUnitCircle.normalized;
    }

    private void MoveNext(Vector2 direction)
    {
        _rigidbody.AddForce(direction * _speedForce, ForceMode2D.Force);
    }

    private void StartRotate()
    {
        _rigidbody.AddTorque(_startTorque);
    }
}
