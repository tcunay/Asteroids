using UnityEngine;
using Weapons.Shells;

namespace Weapons
{
    public class BulletWeapon : Weapon
    {
        [SerializeField] private Bullet _bullet;

        public override void Fire(Transform transform)
        {
            Bullet bullet = Instantiate(_bullet, transform.position, transform.rotation);
            bullet.Shot(transform.up);
        }
    }
}
