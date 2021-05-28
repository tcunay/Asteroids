using UnityEngine;
using Weapons.Shells;

namespace Weapons
{
    public class BulletWeapon : Weapon
    {
        [SerializeField] private Bullet _bullet;

        protected override void Fire(Transform firePoint)
        {
            Bullet bullet = Instantiate(_bullet, firePoint.position, firePoint.rotation);
            bullet.Shot(firePoint.up);
        }
    }
}
