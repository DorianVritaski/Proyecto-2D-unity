using UnityEngine;

namespace HeresyRun.Interactables
{
    /// <summary>
    /// Activa mensaje de tutorial contextual al entrar en trigger.
    /// </summary>
    public class TutorialTrigger : MonoBehaviour
    {
        [SerializeField, TextArea] private string _message;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<HeresyRun.Player.PlayerController>() != null)
            {
                var hud = FindObjectOfType<HeresyRun.UI.HUDController>();
                hud?.ShowTutorial(_message);
            }
        }
    }
}