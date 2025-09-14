using UnityEngine;
using UnityEngine.UI;
using HeresyRun.Powers;

namespace HeresyRun.UI
{
    public class PowerIconUI : MonoBehaviour
    {
        [SerializeField] private Image _icon;

        public void SetPower(IPower pow)
        {
            _icon.sprite = pow.Icon;
        }
    }
}