using Agava.YandexGames;
using UI.Views;
using UnityEngine;

namespace UI.Buttons
{
    public sealed class LeaderboardButton : GameButton
    {
        [SerializeField] private LeaderboardView _leaderboard;
        
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
            
            _leaderboard.gameObject.SetActive(true);
        }
    }
}