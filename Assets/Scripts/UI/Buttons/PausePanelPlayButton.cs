using UI.Panels;
using UnityEngine;

namespace UI.Buttons
{
    public sealed class PausePanelPlayButton : GameButton
    {
        [SerializeField] private PausePanel _pausePanel;
        
        protected override void OnClick()
        {
            Unpause();
        }
        
        private void Unpause()
        {
            Time.timeScale = 1;
            _pausePanel.gameObject.SetActive(false);
        }
    }
}