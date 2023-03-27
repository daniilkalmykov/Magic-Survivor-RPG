using Agava.YandexGames;
using UI.Panels;
using UI.Views;
using UnityEngine;
using Leaderboard = YandexSDK.Leaderboard;

namespace UI.Buttons
{
    public sealed class LoginAcceptButton : GameButton
    {
        [SerializeField] private Leaderboard _leaderboard;
        [SerializeField] private LeaderboardView _leaderboardView;
        
        public void OpenLeaderboard()
        {
            PlayerAccount.Authorize();

            if (PlayerAccount.IsAuthorized)
                PlayerAccount.RequestPersonalProfileDataPermission();
            
            if(PlayerAccount.IsAuthorized == false)
                return;
            
            _leaderboardView.gameObject.SetActive(true);
            _leaderboard.Fill();
        }

        protected override void OnClick()
        {
            OpenLeaderboard();
        }
    }
}