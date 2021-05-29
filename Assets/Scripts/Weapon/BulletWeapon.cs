using UnityEngine;
using Weapons.Ammunition;

namespace Weapons
{
    public class BulletWeapon : Weapon
    {
        protected override void Shoot(Ammo ammo, Transform firePoint)
        {
            Ammo bullet = Instantiate(ammo, firePoint.position, firePoint.rotation);

            AddList(bullet);
        }
    }
}
