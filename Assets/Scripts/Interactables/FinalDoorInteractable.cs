using UnityEngine;

namespace HeresyRun.Interactables
{
    /// <summary>
    /// Puerta al final. Solo se abre si la dualidad es suficiente en un extremo.
    /// </summary>
    public class FinalDoorInteractable : MonoBehaviour
    {
        [SerializeField] private float _threshold = 0.9f;  // Valor extremo para abrir

        private bool _opened = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_opened) return;
            var player = other.GetComponent<HeresyRun.Player.PlayerController>();
            if (player == null) return;

            var meter = FindObjectOfType<HeresyRun.Duality.DualityMeter>();
            var state = meter.State;
            if (state == HeresyRun.Duality.DualityState.Faith && meter.Value <= 1.0f - _threshold)
            {
                _opened = true;
                HeresyRun.Core.LevelManager lvl = FindObjectOfType<HeresyRun.Core.LevelManager>();
                lvl.EndLevel(true);
            }
            else if (state == HeresyRun.Duality.DualityState.Heresy && meter.Value >= _threshold)
            {
                _opened = true;
                HeresyRun.Core.LevelManager lvl = FindObjectOfType<HeresyRun.Core.LevelManager>();
                lvl.EndLevel(false);
            }
            // Si está en neutro: no se abre.
        }
    }
}