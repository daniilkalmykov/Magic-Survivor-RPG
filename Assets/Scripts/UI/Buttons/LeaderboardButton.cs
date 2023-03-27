using UI.Panels;
using UnityEngine;

namespace UI.Buttons
{
    public class LeaderboardButton: GameButton
    {
        [SerializeField] private LoginPanel _logInPanel;
        
        protected override void OnClick()
        {
            OpenLoginPanel();
        }

        private void OpenLoginPanel()
        {
            _logInPanel.gameObject.SetActive(true);
        }
    }
}