using UnityEngine;
using UnityEngine.UI;
using HeresyRun.Duality;

namespace HeresyRun.UI
{
    /// <summary>
    /// Actualiza la barra visual dual.
    /// </summary>
    public class DualityBarUI : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _fillFaith;
        [SerializeField] private Image _fillHeresy;

        public void SetValue(float value, DualityState state)
        {
            _slider.value = value;
            _fillFaith.enabled = (state == DualityState.Faith);
            _fillHeresy.enabled = (state == DualityState.Heresy);
        }
    }
}