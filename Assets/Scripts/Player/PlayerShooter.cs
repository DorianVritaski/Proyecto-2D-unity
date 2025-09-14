using UnityEngine;

namespace HeresyRun.Player
{
    /// <summary>
    /// Disparo simple. Dispara hacia adelante/fijo y activa animación.
    /// </summary>
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _fireCooldown = 0.25f;

        private float _lastFireTime = -99;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Core.InputHandler.Instance.GetShoot())
                Fire();
        }

        public void Fire()
        {
            if (Time.time < _lastFireTime + _fireCooldown)
                return;

            _lastFireTime = Time.time;
            Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);

            // Activar animación de disparo
            if (_animator != null)
                _animator.SetTrigger("Shoot");

            // TODO: SFX
        }
    }
}