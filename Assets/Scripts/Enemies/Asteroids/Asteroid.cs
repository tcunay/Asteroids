using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    public class Asteroid : MonoBehaviour, IEnemy, IMultiply
    {
        public void Die()
        {
            TryMultiply();
            Destroy(gameObject);
        }

        public void TryMultiply()
        {
            if (TryGetComponent(out Delimiter delimiter))
                delimiter.Multiply();
        }
    }
}
