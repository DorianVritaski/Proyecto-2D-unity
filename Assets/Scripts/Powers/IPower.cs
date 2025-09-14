using UnityEngine;

namespace HeresyRun.Powers
{
    /// <summary>
    /// Interfaz para poderes de jugador.
    /// </summary>
    public interface IPower
    {
        string Name { get; }
        Sprite Icon { get; }
        float Cooldown { get; }
        bool CanUse { get; }
        void Activate(Vector2 origin, Player.PlayerController player);
        void OnDualityChanged(float dualityValue, Duality.DualityState state);
    }
}