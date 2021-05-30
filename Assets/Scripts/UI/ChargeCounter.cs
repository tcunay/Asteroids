using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Weapons;

namespace UI
{
    public class ChargeCounter : MonoBehaviour
    {
        [SerializeField] private LaserWeapon _laserWeapon;
        [SerializeField] private TMP_Text _chargeText;
        [SerializeField] private Image _loadChargeImage;

        private float _timeAnimation = 0;

        private void OnEnable()
        {
            _laserWeapon.ChargesChanged += OnChargeChanged;
        }

        private void OnDisable()
        {
            _laserWeapon.ChargesChanged -= OnChargeChanged;
        }

        private void Update()
        {
            _timeAnimation += (Time.deltaTime / _laserWeapon.OneAddChargeTime);
            if (_laserWeapon.IsReplenished)
            {
                _loadChargeImage.fillAmount = Mathf.Lerp(0, 1, 1);
            }
            if (_timeAnimation == 1)
                _timeAnimation = 0;
        }

        private void OnChargeChanged(int charges)
        {
            _chargeText.text = charges.ToString();
        }
    }
}
