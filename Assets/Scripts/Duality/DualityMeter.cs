using System.Collections.Generic;
using UnityEngine;

namespace HeresyRun.Duality
{
    /// <summary>
    /// Sistema de dualidad: maneja barra, envía eventos, y notifica listeners.
    /// </summary>
    public class DualityMeter : MonoBehaviour
    {
        [SerializeField, Range(0, 1)] private float _value = 0.5f;
        public float Value => _value;

        public DualityState State => 
            _value < 0.45f ? DualityState.Faith :
            _value > 0.55f ? DualityState.Heresy : DualityState.Neutral;

        private List<IDualityObserver> _observers = new List<IDualityObserver>();

        private void Start() { Notify(); }

        public void AddObserver(IDualityObserver obs)
        {
            if (!_observers.Contains(obs))
                _observers.Add(obs);
        }

        public void RemoveObserver(IDualityObserver obs)
        {
            _observers.Remove(obs);
        }

        public void Modify(float delta)
        {
            _value = Mathf.Clamp01(_value + delta);
            Notify();
        }

        public void SetValue(float val)
        {
            _value = Mathf.Clamp01(val);
            Notify();
        }

        private void Notify()
        {
            foreach (var obs in _observers)
                obs.OnDualityChanged(_value, State);
        }

        public void Reset()
        {
            _value = 0.5f;
            Notify();
        }
    }
}