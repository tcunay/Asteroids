using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] int time;
    private int _currentTime;
    private float _oneSecond = 1;

    public event UnityAction<int> TimeTicked;

    private void Start()
    {
        Start—ountdown(time);
    }
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
            yield break;

        StartCoroutine(TickTime());
    }
}
