using UnityEngine;
using Weapons.Shells;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private KeyCode _fireKey;
        [SerializeField] private Transform _firePoint;

        private void Update()
        {
            if (Input.GetKeyDown(_fireKey))
                Fire(_firePoint);
        }

        public abstract void Fire(Transform transform);
    }
}
