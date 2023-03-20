using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public sealed class LanguagePanel : MonoBehaviour
    {
        [SerializeField] private VolumePanel _volumePanel;
        [SerializeField] private LeaderboardButton _leaderboardButton;

        private void OnEnable()
        {
            _volumePanel.gameObject.SetActive(false);

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