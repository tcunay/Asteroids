using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public event UnityAction Died;

        public virtual void Die()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            Died?.Invoke();
        }
    }
}
