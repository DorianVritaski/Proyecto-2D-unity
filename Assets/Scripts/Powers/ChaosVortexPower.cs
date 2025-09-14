using UnityEngine;
using HeresyRun.Duality;

namespace HeresyRun.Powers
{
    /// <summary>
    /// Poder hereje: Explosión AoE que daña enemigos (y puede dañar al jugador con suficiente herejía).
    /// </summary>
    [CreateAssetMenu(menuName = "HeresyRun/Power/ChaosVortex")]
    public class ChaosVortexPower : ScriptableObject, IPower
    {
        [SerializeField] private string _name = "Vórtice del Caos";
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _cooldown = 8f;
        [SerializeField] private float _damage = 50;
        [SerializeField] private float _radius = 3f;

        private float _lastUsedTime;

        public string Name => _name;
        public Sprite Icon => _icon;
        public float Cooldown => _cooldown;
        public bool CanUse => Time.time >= _lastUsedTime + _cooldown;

        public void Activate(Vector2 origin, Player.PlayerController player)
        {
            if (!CanUse) return;
            _lastUsedTime = Time.time;
            Collider2D[] cols = Physics2D.OverlapCircleAll(origin, _radius);
            foreach (var c in cols)
            {
                var enemy = c.GetComponent<Enemies.EnemyBase>();
                if (enemy != null)
                    enemy.TakeDamage(_damage);

                if (_damage > 50 && c.GetComponent<Player.PlayerController>() != null)
                    c.GetComponent<Player.PlayerHealth>()?.TakeDamage(10); // autocast penalidad extrema
            }
            // TODO: Partícula/sfx
        }

        public void OnDualityChanged(float dualityValue, DualityState state)
        {
            // Puede aumentar daño si hay herejía alta
        }
    }
}