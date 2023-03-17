using Constants;
using Lean.Localization;
using UnityEngine;

namespace UI.Buttons
{
    public class LanguageButton : GameButton
    {
        [SerializeField] private string _language;
        [SerializeField] private LeanLocalization _leanLocalization;
        
        protected override void OnClick()
        {
            SwitchLanguage();
        }

        private void SwitchLanguage()
        {
            _leanLocalization.CurrentLanguage = _language;
            PlayerPrefs.SetString(PlayerPrefsConstants.Language, _language);
        }
    }
}