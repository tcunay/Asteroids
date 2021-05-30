using UnityEngine;
using TMPro;
using Players;

namespace UI
{
    public class PointsCounter : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private TMP_Text _scoreText;

        private void OnEnable()
        {
            _player.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            _player.ScoreChanged -= OnScoreChanged;
        }

        public void OnScoreChanged(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}
