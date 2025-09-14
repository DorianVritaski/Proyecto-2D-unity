using UnityEngine;

namespace HeresyRun.UI
{
    /// <summary>
    /// Controla display de HUD, referencias a barras e indicadores.
    /// </summary>
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private DualityBarUI _dualityBar;
        [SerializeField] private PowerIconUI _powerIcon;
        [SerializeField] private HealthUI _healthUi;
        [SerializeField] private ObjectiveIndicator _objectiveIndicator;
        [SerializeField] private GameObject _endingPanel;
        [SerializeField] private TMPro.TextMeshProUGUI _endingText;
        [SerializeField] private TMPro.TextMeshProUGUI _tutorialText;

        public void SetDuality(float value, HeresyRun.Duality.DualityState state)
        {
            _dualityBar?.SetValue(value, state);
        }

        public void SetHealth(int current, int max)
        {
            _healthUi?.SetValue(current, max);
        }

        public void SetPower(HeresyRun.Powers.IPower pow)
        {
            _powerIcon?.SetPower(pow);
        }

        public void ShowObjective(string objective)
        {
            _objectiveIndicator?.ShowObjective(objective);
        }

        public void ShowTutorial(string msg)
        {
            _tutorialText.text = msg;
            _tutorialText.gameObject.SetActive(true);
            CancelInvoke(nameof(HideTutorial));
            Invoke(nameof(HideTutorial), 5.0f);
        }

        private void HideTutorial() => _tutorialText.gameObject.SetActive(false);

        public void ShowEnding(string msg)
        {
            _endingPanel.SetActive(true);
            _endingText.text = msg;
        }
    }
}