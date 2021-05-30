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
            TryStartReplenishingAnimation();
        }

        private void OnChargeChanged(int charges)
        {
            _chargeText.text = charges.ToString();
            ResetReplenishingAnimation();
        }

        private void TryStartReplenishingAnimation()
        {
            if (_laserWeapon.IsReplenished)
            {
                StartReplenishingAnimation();
            }
        }

        private void StartReplenishingAnimation()
        {
            _timeAnimation += (Time.deltaTime / _laserWeapon.OneAddChargeTime);
            _loadChargeImage.fillAmount = Mathf.Lerp(0, 1, _timeAnimation);
        }

        private void ResetReplenishingAnimation()
        {
            _timeAnimation = 0;
        }
    }
}
