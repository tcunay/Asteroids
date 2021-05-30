using UnityEngine;
using Weapons;

namespace Players
{
    [RequireComponent(typeof(Player))]
    public class PlayerShoot : MonoBehaviour
    {
        private Player _player;
        private Weapon[] _weapons;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _weapons = GetComponents<Weapon>();
        }

        private void OnEnable()
        {
            if (_weapons != null)
                foreach (var item in _weapons)
                {
                    item.Killed += AddPointToPlayer;
                }
        }

        private void OnDisable()
        {
            if (_weapons != null)
                foreach (var item in _weapons)
                {
                    item.Killed -= AddPointToPlayer;
                }
        }

        private void AddPointToPlayer()
        {
            _player.AddScore();
        }
    }
}
