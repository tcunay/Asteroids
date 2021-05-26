using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private int _health;

        private void ApplyDamage(int damage)
        {
            if (damage >= 0)
                _health -= damage;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

        }
    }
}
