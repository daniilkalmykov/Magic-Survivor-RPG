using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class SettingsButton : GameButton
    {
        [SerializeField] private Image _settingsPanel;
        
        protected override void OnClick()
        {
            OpenSettingsPanel();
        }

        private void OpenSettingsPanel()
        {
            _settingsPanel.gameObject.SetActive(true);
        }
    }
}