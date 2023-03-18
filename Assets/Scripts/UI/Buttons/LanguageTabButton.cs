using UI.Panels;
using UnityEngine;

namespace UI.Buttons
{
    public sealed class LanguageTabButton : GameButton
    {
        [SerializeField] private LanguagePanel _languagePanel;
        
        protected override void OnClick()
        {
            OpenLanguagePanel();
        }

        private void OpenLanguagePanel()
        {
            _languagePanel.gameObject.SetActive(true);
        }
    }
}