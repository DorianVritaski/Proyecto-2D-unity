using UnityEngine;
using HeresyRun.Duality;

namespace HeresyRun.Enemies
{
    /// <summary>
    /// Base para enemigos. Patrón Observer de dualidad.
    /// </summary>
    public class EnemyBase : MonoBehaviour, IDualityObserver
    {
        [SerializeField] protected float _maxHealth = 40;
        protected float _health;
        [SerializeField] protected int _damage = 15;
        protected bool _dead;

        protected virtual void Awake()
        {
            _health = _maxHealth;
        }

        public virtual void TakeDamage(float dmg)
        {
            if (_dead) return;
            _health -= dmg;
            if (_health <= 0)
                Die();
        }

        protected virtual void Die()
        {
            _dead = true;
            gameObject.SetActive(false);
        }

        public virtual void OnDualityChanged(float value, DualityState state)
        {
            // Puede sobrescribirse para cambiar comportamiento visual/AI.
        }

        protected virtual void Update()
        {
            // Patrulla/Mirar al jugador (tuneable en hijos)
        }
    }
}