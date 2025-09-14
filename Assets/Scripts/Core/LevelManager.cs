using UnityEngine;

namespace HeresyRun.Core
{
    /// <summary>
    /// Controla progreso, segmentos y eventos de victoria/derrota.
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Transform[] _segmentEntrances;

        public void GoToSegment(int seg)
        {
            // Asume teleport/trigger posicional o inicia eventos de sección.
            // Por expandir en futuros niveles.
        }

        public void SegmentCompleted(int seg)
        {
            // Lógica de paso al siguiente segmento.
        }

        public void EndLevel(bool byFaith)
        {
            GameManager.Instance.OnGameWon(byFaith);
        }
    }
}