using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Weapons.Ammunition;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private Ammo _ammo;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Button _button;
        [SerializeField] private KeyCode _fireKey;

        private List<Ammo> _ammos = new List<Ammo>();

        public event UnityAction Killed;

        private void OnEnable()
        {
            _button.onClick.AddListener(() => Shoot(_ammo, _firePoint));
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(() => Shoot(_ammo, _firePoint));
        }
        protected virtual void Update()
        {
            if (Input.GetKeyDown(_fireKey))
                Shoot(_ammo, _firePoint);
        }

        protected void AddList(Ammo ammo)
        {
            _ammos.Add(ammo);
            ammo.Killed += ReportKilling;
        }

        protected void RemoveList(Ammo ammo)
        {
            _ammos.Remove(ammo);
            ammo.Killed -= ReportKilling;
        }

        private void ReportKilling()
        {
            Killed?.Invoke();
        }

        protected abstract void Shoot(Ammo ammo, Transform firePoint);
    }
}
