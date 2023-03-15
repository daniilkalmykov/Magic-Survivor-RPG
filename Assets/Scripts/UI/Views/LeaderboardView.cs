using System.Collections.Generic;
using Agava.YandexGames;
using GameLogic;
using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;
using YandexSDK;
using Leaderboard = YandexSDK.Leaderboard;

namespace UI.Views
{
    public sealed class LeaderboardView : MonoBehaviour
    {
        [SerializeField] private Leaderboard _leaderboard;
        [SerializeField] private LeaderboardPlayerView _leaderboardPlayerView;
        [SerializeField] private Image _label;
        [SerializeField] private CloseButton _closeButton;
        
        private readonly List<LeaderboardPlayerView> _spawnedPlayerViews = new();

        private void Start()
        {
            Clear();
            CreateLeaderboard();
            _label.gameObject.SetActive(true);
            _closeButton.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            _label.gameObject.SetActive(false);
            _closeButton.gameObject.SetActive(false);
        }

        private void CreateLeaderboard()
        {
            _leaderboard.Clear();
            _leaderboard.Fill();            

            if(PlayerAccount.IsAuthorized == false)
                return;
            
            var players = _leaderboard.GetPlayers();

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