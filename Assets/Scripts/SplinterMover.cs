using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies;

public class SplinterMover : AsteroidMover
{
    private float _lifeTime = 5;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}
