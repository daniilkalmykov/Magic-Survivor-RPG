using System.Collections.Generic;
using GameLogic;
using UI.Buttons;
using UnityEngine;
using YandexSDK;

namespace UI.Views
{
    public sealed class LeaderboardView : MonoBehaviour
    {
        [SerializeField] private Leaderboard _leaderboard;
        [SerializeField] private LeaderboardPlayerView _leaderboardPlayerView;
        [SerializeField] private CloseButton _closeButton;

        private readonly List<LeaderboardPlayerView> _spawnedPlayerViews = new();

        private void OnEnable()
        {
            CreateLeaderboard();
            _closeButton.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            Clear();
            _closeButton.gameObject.SetActive(false);
        }

        private void CreateLeaderboard()
        {
            _leaderboard.Clear();
            _leaderboard.Fill();            

            var players = _leaderboard.GetPlayers();

            foreach (var player in players)
            {
                var leaderboardPlayerView = Instantiate(_leaderboardPlayerView, transform);
                
                leaderboardPlayerView.gameObject.SetActive(false);
                leaderboardPlayerView.Init(player.Name, Timer.ConvertIntToTime(player.Score));
                leaderboardPlayerView.gameObject.SetActive(true);

                _spawnedPlayerViews.Add(leaderboardPlayerView);
            }
        }
        
        private void Clear()
        {
            foreach (var playerView in _spawnedPlayerViews)
                Destroy(playerView);
            
            _spawnedPlayerViews.Clear();
        }
    }
}