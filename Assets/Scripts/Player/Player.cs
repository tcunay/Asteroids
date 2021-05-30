using UnityEngine;
using Enemies;
using UnityEngine.Events;

namespace Players
{
    public class Player : MonoBehaviour
    {
        private int _score;

        public int Score => _score;

        public event UnityAction Dying;
        public event UnityAction<int> ScoreChanged;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Enemy enemy))
                Die();
        }

        private void Die()
        {
            Dying?.Invoke();
        }

        public void AddScore()
        {
            _score++;
            ScoreChanged?.Invoke(_score);
        }
    }
}
