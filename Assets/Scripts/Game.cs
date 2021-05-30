using UnityEngine;
using UnityEngine.SceneManagement;
using Players;

namespace Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Timer _timer;
        [SerializeField] private GameObject _missionFailedMenu;
        [SerializeField] private int _gameTime;

        private bool _isGameOver = false;

        private void OnEnable()
        {
            _player.Dying += OnGameOver;
            _timer.TickEnded += OnGameOver;
        }

        private void OnDisable()
        {
            _player.Dying -= OnGameOver;
            _timer.TickEnded -= OnGameOver;
        }

        private void Start()
        {
            _timer.Start—ountdown(_gameTime);
        }

        public void OnGameOver()
        {
            if (_isGameOver == true) return;

            _player.gameObject.SetActive(false);
            _missionFailedMenu.SetActive(true);
            _isGameOver = true;
        }

        public void RestartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
