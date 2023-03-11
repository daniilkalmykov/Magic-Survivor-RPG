using GameLogic;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Text))]
    public sealed class HighestScoreView : MonoBehaviour
    {
        private TMP_Text _score;

        private void Awake()
        {
            _score = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            _score.text = Timer.ScoreSeconds.ToString().Length == 1
                ? $"{Timer.ScoreMinutes} : 0{Timer.ScoreSeconds}"
                : $"{Timer.ScoreMinutes} : {Timer.ScoreSeconds}";
        }
    }
}