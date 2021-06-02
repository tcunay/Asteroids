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
            _laserWeapon.ChargesIncreased += OnChargeIncreased;
            _laserWeapon.ChargesDecreased += OnChargeDecreased;
        }

        private void OnDisable()
        {
            _laserWeapon.ChargesIncreased -= OnChargeIncreased;
            _laserWeapon.ChargesDecreased -= OnChargeDecreased;
        }

        private void Update()
        {
            TryStartReplenishingAnimation();
        }

        private void OnChargeDecreased(int charges)
        {
            SetChargeCount(charges);
        }

        private void OnChargeIncreased(int charges)
        {
            SetChargeCount(charges);
            ResetReplenishingAnimation();
        }

        private void SetChargeCount(int charges)
        {
            _chargeText.text = charges.ToString();
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
