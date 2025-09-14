using UnityEngine;
using HeresyRun.Powers;
using HeresyRun.Duality;

namespace HeresyRun.Player
{
    /// <summary>
    /// Permite al jugador alternar/usar poderes activos según dualidad.
    /// </summary>
    public class PlayerPowerHandler : MonoBehaviour, IDualityObserver
    {
        [SerializeField] private IPower[] _availablePowersDefault;
        private IPower[] _currentPowers;
        private int _selectedPowerIndex = 0;

        private DualityState _state;
        private float _dualityValue;

        private void Start()
        {
            _currentPowers = _availablePowersDefault;
            Duality.DualityMeter meter = FindObjectOfType<Duality.DualityMeter>();
            meter?.AddObserver(this);
        }

        private void Update()
        {
            if (Core.InputHandler.Instance.GetSwitchPowerNext())
                SwitchPower(1);
            if (Core.InputHandler.Instance.GetSwitchPowerPrev())
                SwitchPower(-1);

            if (Core.InputHandler.Instance.GetPower())
                UseCurrentPower();
        }

        private void SwitchPower(int dir)
        {
            if (_currentPowers == null || _currentPowers.Length == 0) return;
            _selectedPowerIndex = (_selectedPowerIndex + dir + _currentPowers.Length) % _currentPowers.Length;
            // Actualizar UI Power.
        }

        private void UseCurrentPower()
        {
            if (_currentPowers == null || _currentPowers.Length == 0) return;
            _currentPowers[_selectedPowerIndex].Activate(transform.position, GetComponent<PlayerController>());
        }

        public IPower CurrentPower => _currentPowers?[_selectedPowerIndex];

        public void OnDualityChanged(float value, DualityState state)
        {
            _dualityValue = value;
            _state = state;
            foreach (var pow in _currentPowers)
                pow.OnDualityChanged(value, state);
        }
    }
}