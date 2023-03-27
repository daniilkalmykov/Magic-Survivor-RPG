using UI.Panels;
using UnityEngine;

namespace UI.Buttons
{
    public class LoginDeclineButton : GameButton
    {
        [SerializeField] private LoginPanel _loginPanel;

        protected override void OnClick()
        {
            Decline();
        }

        private void Decline()
        {
            _loginPanel.gameObject.SetActive(false);
        }
    }
}