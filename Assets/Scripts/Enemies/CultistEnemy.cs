using UnityEngine;
using HeresyRun.Duality;

namespace HeresyRun.Enemies
{
    /// <summary>
    /// Cultista básico de rango o melee. Cambia comportamiento si la dualidad lo permite.
    /// </summary>
    public class CultistEnemy : EnemyBase
    {
        [SerializeField] private bool _isRanged = false;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _attackCooldown = 1.5f;
        [SerializeField] private float _moveSpeed = 2.5f;
        [SerializeField] private Transform _playerRef;

        private float _lastAttackTime;

        protected override void Update()
        {
            if (_dead) return;
            // Seek player simple
            if (_playerRef == null)
                _playerRef = GameObject.FindGameObjectWithTag("Player")?.transform;

            if (_playerRef != null)
            {
                float dist = Vector2.Distance(_playerRef.position, transform.position);
                if (_isRanged)
                {
                    if (dist < 7f && Time.time > _lastAttackTime + _attackCooldown)
                    {
                        Fire();
                        _lastAttackTime = Time.time;
                    }
                }
                else if (dist > 1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, _playerRef.position, _moveSpeed * Time.deltaTime);
                }
            }
        }

        private void Fire()
        {
            if (_bulletPrefab != null && _firePoint != null)
                Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            // SFX, partículas
        }

        public override void OnDualityChanged(float value, DualityState state)
        {
            // Aumenta agresividad si State == Heresy, baja si es Fe.
            _moveSpeed = (state == DualityState.Heresy) ? 3.5f : 2.0f;
            _attackCooldown = (state == DualityState.Heresy) ? 1.0f : 2.0f;
        }
    }
}