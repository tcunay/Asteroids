using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private int _currentTime;
    private float _oneSecond = 1;

    public event UnityAction<int> TimeTicked;
    public event UnityAction TickEnded;

    public void Start—ountdown(int time)
    {
        _currentTime = time;
        StartCoroutine(TickTime());
    }

    private IEnumerator TickTime()
    {
        yield return new WaitForSeconds(_oneSecond);

        _currentTime--;
        TimeTicked?.Invoke(_currentTime);

        if (_currentTime == 0)
        {
            TickEnded?.Invoke();
            yield break;
        }

        StartCoroutine(TickTime());
    }
}
