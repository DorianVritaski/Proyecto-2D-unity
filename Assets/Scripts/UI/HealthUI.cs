using UnityEngine;
using UnityEngine.UI;

namespace HeresyRun.UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void SetValue(int current, int max)
        {
            _slider.maxValue = max;
            _slider.value = current;
        }
    }
}