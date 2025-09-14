using UnityEngine;

namespace HeresyRun.Core
{
    /// <summary>
    /// Abstracción de input para integrar fácil con Input System futuro.
    /// </summary>
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        public float GetHorizontal()
        {
            return Input.GetAxis("Horizontal");
        }

        public bool GetJump()
        {
            return Input.GetButtonDown("Jump");
        }

        public bool GetShoot()
        {
            return Input.GetKeyDown(KeyCode.J);
        }

        public bool GetPower()
        {
            return Input.GetKeyDown(KeyCode.K);
        }

        public bool GetSwitchPowerNext()
        {
            return Input.GetKeyDown(KeyCode.E);
        }

        public bool GetSwitchPowerPrev()
        {
            return Input.GetKeyDown(KeyCode.Q);
        }

        public bool GetPause()
        {
            return Input.GetKeyDown(KeyCode.Escape);
        }
    }
}