using UnityEngine;
using Weapons.Shells;

namespace Weapons
{
    public class LaserWeapon : Weapon
    {
        [SerializeField] private Laser _laser;

        private int _chargesQuantity = 5;

        public override void Fire(Transform transform)
        {
            if(_chargesQuantity > 0)
            {
                Laser laser = Instantiate(_laser, transform);
                laser.Shot(transform.localPosition);
            }
        }
    }
}
