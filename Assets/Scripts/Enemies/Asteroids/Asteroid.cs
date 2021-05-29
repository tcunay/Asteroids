using UnityEngine;
using UnityEngine.Events;

namespace Enemies
{
    public class Asteroid : Enemy, IMultiply
    {
        public override void Die()
        {
            TryMultiply();
            base.Die();
        }

        public void TryMultiply()
        {
            if (TryGetComponent(out Delimiter delimiter))
                delimiter.Multiply();
        }
    }
}
