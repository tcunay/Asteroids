using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Zone _zone;
    [SerializeField] private Enemy _template;
    [SerializeField] private int _maxCountAtOneTime;
    [SerializeField] private float _secondsBetweenSpawn;

    private List<Enemy> _enemies = new List<Enemy>();
    private Vector3[] _spawnPoints;
    private int _countAtOneTime;
    private float _elapsedTime;
    private float _centerOffset = 3;
    private bool _isSpawnPointsCompleted = false;

    private void OnEnable()
    {
        _zone.Creating += SetSpawnPoints;
    }

    private void OnDisable()
    {
        _zone.Creating -= SetSpawnPoints;
    }

    private void Update()
    {
        TrySpawn();
    }

    private void TrySpawn()
    {
        if (_isSpawnPointsCompleted == false)
            return;

        _elapsedTime += Time.deltaTime;
        if (IsFull() == false)
        {
            if (_elapsedTime >= _secondsBetweenSpawn)
            {
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(_template, GetRandomPoint(), Quaternion.identity);

        enemy.Died += Reduce;
        _enemies.Add(enemy);

        _countAtOneTime++;
        _elapsedTime = 0;
    }

    private bool IsFull()
    {
        return _countAtOneTime >= _maxCountAtOneTime;
    }

    private Vector3 GetRandomPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Length)];
    }

    private void Reduce(Enemy enemy)
    {
        _countAtOneTime--;

        _enemies.Remove(enemy);
        enemy.Died -= Reduce;
    }

    public void SetSpawnPoints(Vector3[] points)
    {
        _spawnPoints = new Vector3[points.Length];

        for (int i = 0; i < points.Length; i++)
        {
            _spawnPoints[i] = DirectÑloserToCenter(points[i]);
        }

        _isSpawnPointsCompleted = true;
    }

    private Vector3 DirectÑloserToCenter(Vector3 point)
    {
        return point - (_zone.Center.position + point.normalized * _centerOffset);
    }
}
