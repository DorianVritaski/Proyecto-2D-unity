using UnityEngine;

namespace HeresyRun.Interactables
{
    /// <summary>
    /// Interacción para sacrificar y ganar herejía.
    /// </summary>
    public class PrisonerInteractable : MonoBehaviour
    {
        [SerializeField] private float _heresyIncrease = 0.2f;

        private bool _used = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_used) return;
            var player = other.GetComponent<HeresyRun.Player.PlayerController>();
            if (player != null)
            {
                _used = true;
                var meter = FindObjectOfType<HeresyRun.Duality.DualityMeter>();
                meter?.Modify(_heresyIncrease);
                // Dar poder herejía o penalización.
            }
        }
    }
}