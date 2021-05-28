using UnityEngine;

namespace Enemies
{
    public class Asteroid : MonoBehaviour, IEnemy
    {
        public void Die()
        {
            Destroy(gameObject);
        }
    }
}
