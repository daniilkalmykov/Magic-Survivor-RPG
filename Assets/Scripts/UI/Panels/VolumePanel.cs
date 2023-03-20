using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public sealed class VolumePanel : MonoBehaviour
    {
        [SerializeField] private LanguagePanel _languagePanel;
        [SerializeField] private LeaderboardButton _leaderboardButton;
        
        private void OnEnable()
        {
            _languagePanel.gameObject.SetActive(false);
            
            if (_leaderboardButton.TryGetComponent(out Button button))
                button.interactable = false;
        }
        
        private void OnDisable()
        {
            if (_leaderboardButton.TryGetComponent(out Button button))
                button.interactable = true;
        }
    }
}