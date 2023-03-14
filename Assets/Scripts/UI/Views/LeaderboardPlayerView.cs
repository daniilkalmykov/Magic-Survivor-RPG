using TMPro;
using UnityEngine;

namespace UI.Views
{
    public sealed class LeaderboardPlayerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerNameText;
        [SerializeField] private TMP_Text _scoreText;

        private string _playerName;
        private string _score;
        
        private void OnEnable()
        {
            _playerNameText.text = _playerName;
            _scoreText.text = _score;
        }
            
        public void Init(string playerName, string score)
        {
            _playerName = playerName;
            _score = score;
        }
    }
}