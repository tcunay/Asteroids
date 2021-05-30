using UnityEngine;
using Players;

namespace Effects
{

    [RequireComponent(typeof(ParticleSystem))]
    public class ExhaustEffect : MonoBehaviour
    {
        private ParticleSystem _exhaustParticles;
        private PlayerMover _player;
        private float _minRate = 0;
        private float _maxRate = 20;

        private void Start()
        {
            _exhaustParticles = GetComponent<ParticleSystem>();
            _player = GetComponentInParent<PlayerMover>();
        }

        private void Update()
        {
            TurnOnEffects();
        }

        private void TurnOnEffects()
        {
            if (_player.IsEngine)
                SetRate(_maxRate);
            else
                SetRate(_minRate);
        }

        private void SetRate(float rate)
        {
            var emission = _exhaustParticles.emission;
            emission.rateOverTime = rate;
        }
    }
}
