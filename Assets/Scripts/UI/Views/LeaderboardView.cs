using System.Collections.Generic;
using GameLogic;
using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;
using YandexSDK;

namespace UI.Views
{
    public sealed class LeaderboardView : MonoBehaviour
    {
        [SerializeField] private LeaderboardPlayerView _leaderboardPlayerView;
        [SerializeField] private Image _label;
        [SerializeField] private CloseButton _closeButton;
        [SerializeField] private SettingsButton _settingsButton;
        [SerializeField] private HighestScoreView _highestScoreView;

        private readonly List<LeaderboardPlayerView> _spawnedPlayerViews = new();

        private void OnEnable()
        {
            _label.gameObject.SetActive(true);
            _closeButton.gameObject.SetActive(true);

            if (_settingsButton.TryGetComponent(out Button button))
                button.interactable = false;
            
            _highestScoreView.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _label.gameObject.SetActive(false);
            _closeButton.gameObject.SetActive(false);

            if (_settingsButton.TryGetComponent(out Button button))
                button.interactable = true;
            
            _highestScoreView.gameObject.SetActive(true);
        }

        public void Create(List<LeaderboardPlayer> players)
        {
            Clear();                                      

            foreach (var player in players)
            {
                var leaderboardPlayerView = Instantiate(_leaderboardPlayerView, transform);
                leaderboardPlayerView.Init(player.Name, Timer.ConvertIntToTime(player.Score));

                _spawnedPlayerViews.Add(leaderboardPlayerView);
            }
        }

        private void Clear()
        {
            foreach (var playerView in _spawnedPlayerViews)
                Destroy(playerView.gameObject);
        
            _spawnedPlayerViews.Clear();
        }
    }
}