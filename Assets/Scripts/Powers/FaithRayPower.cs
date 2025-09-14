using UnityEngine;
using HeresyRun.Duality;

namespace HeresyRun.Powers
{
    /// <summary>
    /// Poder de la Fe: cura en área.
    /// </summary>
    [CreateAssetMenu(menuName = "HeresyRun/Power/FaithRay")]
    public class FaithRayPower : ScriptableObject, IPower
    {
        [SerializeField] private string _name = "Rayo de Fe";
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _cooldown = 6f;
        [SerializeField] private float _radius = 2.5f;
        [SerializeField] private float _healAmount = 30;

        private float _lastUsedTime;

        public string Name => _name;
        public Sprite Icon => _icon;
        public float Cooldown => _cooldown;
        public bool CanUse => Time.time >= _lastUsedTime + _cooldown;

        public void Activate(Vector2 origin, Player.PlayerController player)
        {
            if (!CanUse) return;
            // TODO: Mostrar particle y sonido
            _lastUsedTime = Time.time;
            Collider2D[] cols = Physics2D.OverlapCircleAll(origin, _radius);
            foreach (var c in cols)
            {
                var ph = c.GetComponent<Player.PlayerHealth>();
                if (ph != null)
                    ph.Heal(_healAmount);
                // Puedes agregar curación a aliados más adelante.
            }
        }

        public void OnDualityChanged(float dualityValue, DualityState state)
        {
            // Puede modificar curación si quieres según estado extremo.
        }
    }
}