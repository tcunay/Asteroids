using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies;
using UnityEngine.Events;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private int _score;

        public event UnityAction Dying;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IEnemy enemy))
                Die();
        }

        private void Die()
        {
            Dying?.Invoke();
        }

        public void AddScore()
        {
            _score++;
        }
    }
}
