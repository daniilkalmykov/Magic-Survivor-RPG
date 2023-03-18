using Constants;
using Lean.Localization;
using UnityEngine;

namespace UI.Buttons
{
    public class LanguageButton : GameButton
    {
        [SerializeField] private string _language;
        
        protected override void OnClick()
        {
            SwitchLanguage();
        }

        private void SwitchLanguage()
        {
            LeanLocalization.SetCurrentLanguageAll(_language);
            LeanLocalization.UpdateTranslations();
            
            PlayerPrefs.SetString(PlayerPrefsConstants.Language, _language);
        }
    }
}