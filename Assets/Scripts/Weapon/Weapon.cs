using System;
using UnityEngine;
using Weapons.Shells;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private KeyCode _fireKey;
        [SerializeField] private Transform _firePoint;

        protected virtual void Update()
        {
            if(Input.GetKeyDown(_fireKey))
                Fire(_firePoint);
        }

        protected abstract void Fire(Transform firePoint);
    }
}
