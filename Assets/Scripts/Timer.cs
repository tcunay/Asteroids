using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private int _currentTime;
    private float _oneSecond = 1;
    private bool _isTicking;

    public event UnityAction<int> TimeTicked;
    public event UnityAction TickEnded;

    public void DoStart(int time)
    {
        _currentTime = time;
        _isTicking = true;
        StartCoroutine(TickTime());
    }

    public void StopTick()
    {
        if (_isTicking == true)
        {
            _isTicking = false;
            TickEnded?.Invoke();
        }
    }

    private IEnumerator TickTime()
    {
        yield return new WaitForSeconds(_oneSecond);

        _currentTime--;
        TimeTicked?.Invoke(_currentTime);

        if (_currentTime == 0)
            StopTick();

        if (_isTicking)
            StartCoroutine(TickTime());
        else
            yield break;
    }
}
