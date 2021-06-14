using UnityEngine;
using UnityEngine.Events;

namespace Weapons.Ammunition
{
    public abstract class Ammo : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;

        public event UnityAction Killed;
        public event UnityAction Died;

        protected virtual void Start()
        {
            Destroy(gameObject, _lifeTime);
        }

        private void OnDestroy()
        {
            Died?.Invoke();
        }

        protected abstract void Shot();

        protected void ReportKilled()
        {
            Killed?.Invoke();
        }
    }
}
