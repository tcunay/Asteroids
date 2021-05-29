using UnityEngine;
using UnityEngine.Events;

namespace Weapons.Ammunition
{
    public abstract class Ammo : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;

        public event UnityAction Killed;
        public event UnityAction Die;

        protected virtual void Start()
        {
            Destroy(gameObject, _lifeTime);
        }

        private void OnDestroy()
        {
            Die?.Invoke();
        }

        protected abstract void Shot();

        protected void ReportKilled()
        {
            Killed?.Invoke();
        }
    }
}
