using Agava.YandexGames;
using UI.Views;
using UnityEngine;
using Leaderboard = YandexSDK.Leaderboard;

namespace UI.Buttons
{
    public sealed class LeaderboardButton : GameButton
    {
        [SerializeField] private Leaderboard _leaderboard;
        [SerializeField] private LeaderboardView _leaderboardView;
        
        protected override void OnClick()
        {
            OpenLeaderboard();
        }

        private void OpenLeaderboard()
        {
            PlayerAccount.Authorize();

            if (PlayerAccount.IsAuthorized)
                PlayerAccount.RequestPersonalProfileDataPermission();
            
            if(PlayerAccount.IsAuthorized == false)
                return;
            
            _leaderboardView.gameObject.SetActive(true);
            _leaderboard.Fill();
        }
    }
}