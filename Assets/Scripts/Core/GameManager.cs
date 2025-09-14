using UnityEngine;
using HeresyRun.Player;
using HeresyRun.Duality;
using HeresyRun.UI;


namespace HeresyRun.Core
{
    /// <summary>
    /// Singleton que maneja el estado global del juego y referencia sistemas principales.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public Player.PlayerController Player { get; private set; }
        public Duality.DualityMeter DualityMeter { get; private set; }
        public UI.HUDController Hud { get; private set; }
        public Core.LevelManager LevelManager { get; private set; }

        private void Awake()
        {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            } else {
                Destroy(gameObject);
                return;
            }

            // Buscar referencias a sistemas principales (opcional: asignar después via inspector)
            Player = FindObjectOfType<Player.PlayerController>();
            DualityMeter = FindObjectOfType<Duality.DualityMeter>();
            Hud = FindObjectOfType<UI.HUDController>();
            LevelManager = FindObjectOfType<Core.LevelManager>();
        }

        public void OnGameWon(bool byFaith)
        {
            Hud.ShowEnding(byFaith ? "Victoria por la Fe" : "Victoria Hereje");
            // Otros efectos, stats, reset nivel...
        }

        public void OnGameLost()
        {
            Hud.ShowEnding("Derrota");
        }
    }
}