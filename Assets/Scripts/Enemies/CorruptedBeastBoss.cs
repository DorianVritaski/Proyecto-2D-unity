using UnityEngine;
using HeresyRun.Duality;

namespace HeresyRun.Enemies
{
    /// <summary>
    /// Mini jefe: puede tener patrones distintos según dualidad.
    /// </summary>
    public class CorruptedBeastBoss : EnemyBase
    {
        [SerializeField] private float _rageThreshold = 0.7f;
        [SerializeField] private float _attackInterval = 2f;
        private float _lastAttackTime;
        private Transform _playerRef;

        private bool _enraged;

        protected override void Update()
        {
            if (_dead) return;
            if (_playerRef == null)
                _playerRef = GameObject.FindGameObjectWithTag("Player")?.transform;

            if (_playerRef != null && Time.time > _lastAttackTime + _attackInterval)
            {
                Attack();
                _lastAttackTime = Time.time;
            }
        }

        private void Attack()
        {
            // Ejemplo: lanzar proyectil, saltar, llamar ondas AoE, etc.
        }

        public override void OnDualityChanged(float value, DualityState state)
        {
            // La bestia se vuelve más feroz si hay mucha herejía...
            if (value > _rageThreshold)
            {
                _enraged = true;
                _attackInterval = 1f;
                _damage = 30;
            }
            else if(value < 1f - _rageThreshold)
            {
                _enraged = false;
                _attackInterval = 2.5f;
                _damage = 10;
            }
            else
            {
                _attackInterval = 2f;
                _damage = 20;
            }
        }

        protected override void Die()
        {
            base.Die();
            // Lanza loot, efecto especial, abre ruta, etc.
        }
    }
}