using System.Collections;
using UnityEngine;
using Weapons.Ammunition;

namespace Weapons
{
    public class LaserWeapon : Weapon
    {
        private int _maxChargesQuantity = 5;
        private int _chargesQuantity;
        private float _oneAddChargeTime = 5f;
        private bool _isReplenished = false;

        protected override void Update()
        {
            base.Update();
            TryAddCharge();
        }

        protected override void Shoot(Ammo ammo, Transform firePoint)
        {
            if(true)//(_chargesQuantity > 0)
            {
                Ammo laser = Instantiate(ammo, firePoint);
                AddList(laser);
                _chargesQuantity--;
            }
        }

        private void TryAddCharge()
        {
            if (_chargesQuantity < _maxChargesQuantity && _isReplenished == false)
                StartCoroutine(AddCharge());
        }

        private IEnumerator AddCharge()
        {
            _isReplenished = true;

            yield return new WaitForSeconds(_oneAddChargeTime);

            _chargesQuantity++;
            _isReplenished = false;
        }
    }
}
