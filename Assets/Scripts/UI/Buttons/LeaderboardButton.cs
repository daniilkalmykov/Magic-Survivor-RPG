using Agava.YandexGames;
using UI.Panels;
using UnityEngine;

namespace UI.Buttons
{
    public class LeaderboardButton: GameButton
    {
        [SerializeField] private LoginPanel _logInPanel;
        [SerializeField] private LoginAcceptButton _loginAcceptButton;
        
        protected override void OnClick()
        {
            OpenLoginPanel();
        }

        private void OpenLoginPanel()
        {
            if (PlayerAccount.IsAuthorized == false)
                _logInPanel.gameObject.SetActive(true);
            else
                _loginAcceptButton.OpenLeaderboard();
        }
    }
}