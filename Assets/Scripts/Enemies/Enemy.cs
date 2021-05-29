using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public event UnityAction<Enemy> Died;

        public virtual void Die()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            Died?.Invoke(this);
        }
    }
}
