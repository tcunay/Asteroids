using UnityEngine;
using TMPro;

namespace UI
{
    public class RoundTimeCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timeText;
        [SerializeField] private Timer _timer;

        private void OnEnable()
        {
            _timer.TimeTicked += OnTimeChanged;
        }

        private void OnDisable()
        {
            _timer.TimeTicked -= OnTimeChanged;
        }

        private void OnTimeChanged(int time)
        {
            string minutes = ConvertToString(time / 60);
            string seconds = ConvertToString(time % 60);
            _timeText.text = minutes + ":" + seconds;
        }

        private string ConvertToString(int value)
        {
            if (value.ToString().Length < 2)
                return "0" + value.ToString();
            else
                return value.ToString();
        }

    }
}
