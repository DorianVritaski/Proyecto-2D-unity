using UnityEngine;
using HeresyRun.Core;

namespace HeresyRun.Player
{
    /// <summary>
    /// Vida de jugador con eventos y animaciones.
    /// </summary>
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;
        private int _currentHealth;

        public int CurrentHealth => _currentHealth;
        public int MaxHealth => _maxHealth;

        public System.Action<int, int> OnHealthChanged;
        public System.Action OnDeath;

        private Animator _animator;

        private void Awake()
        {
            _currentHealth = _maxHealth;
            _animator = GetComponent<Animator>();
        }

        public void TakeDamage(int dmg)
        {
            _currentHealth = Mathf.Max(0, _currentHealth - dmg);
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);

            if (_animator != null)
                _animator.SetTrigger("Hurt");

            if (_currentHealth <= 0)
            {
                OnDeath?.Invoke();
                Die();
            }
        }

        public void Heal(float hp)
        {
            _currentHealth = Mathf.Min(_maxHealth, _currentHealth + Mathf.RoundToInt(hp));
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        }

        private void Die()
        {
            if (_animator != null)
                _animator.SetBool("isDead", true);

            GameManager.Instance.OnGameLost();
            gameObject.SetActive(false);
        }
    }
}