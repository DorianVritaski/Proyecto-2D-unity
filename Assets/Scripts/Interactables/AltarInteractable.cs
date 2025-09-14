using UnityEngine;

namespace HeresyRun.Interactables
{
    /// <summary>
    /// Permite rezar para ganar Fe y activar powerup de Fe.
    /// </summary>
    public class AltarInteractable : MonoBehaviour
    {
        [SerializeField] private float _faithIncrease = 0.2f;

        private bool _used = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_used) return;
            var player = other.GetComponent<HeresyRun.Player.PlayerController>();
            if (player != null)
            {
                _used = true;
                var meter = FindObjectOfType<HeresyRun.Duality.DualityMeter>();
                meter?.Modify(-_faithIncrease);
                // Dar power Fe u otro feedback
            }
        }
    }
}