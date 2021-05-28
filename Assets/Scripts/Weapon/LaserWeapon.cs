using System.Collections;
using UnityEngine;
using Weapons.Shells;

namespace Weapons
{
    public class LaserWeapon : Weapon
    {
        [SerializeField] private Laser _laser;

        private int _maxChargesQuantity = 5;
        private int _chargesQuantity;
        private float _oneAddChargeTime = 5f;
        private bool _isReplenished = false;

        protected override void Update()
        {
            base.Update();

            TryAddCharge();
        }

        protected override void Fire(Transform firePoint)
        {
            if(_chargesQuantity > 0)
            {
                Laser laser = Instantiate(_laser, transform);
                laser.Shot(firePoint.localPosition);

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
