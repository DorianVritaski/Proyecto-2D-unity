using UnityEngine;
using TMPro;

namespace HeresyRun.UI
{
    public class ObjectiveIndicator : MonoBehaviour
    {
        [SerializeField] private TMP_Text _objectiveText;

        public void ShowObjective(string obj)
        {
            _objectiveText.text = obj;
            _objectiveText.gameObject.SetActive(true);
            CancelInvoke(nameof(HideObjective));
            Invoke(nameof(HideObjective), 6.0f);
        }

        private void HideObjective()
        {
            _objectiveText.gameObject.SetActive(false);
        }
    }
}