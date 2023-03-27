using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class LoginPanel : MonoBehaviour
    {
        [SerializeField] private SettingsButton _settingsButton;
        [SerializeField] private LeaderboardButton _leaderboardButton;
        [SerializeField] private SoundsButton _soundsButton;
        [SerializeField] private PlayButton _playButton;

        private void OnEnable()
        {
            if (_leaderboardButton.TryGetComponent(out Button button))
                button.interactable = false;

            if (_soundsButton.TryGetComponent(out Button soundsButton))
                soundsButton.interactable = false;

            if (_playButton.TryGetComponent(out Button playButton))
                playButton.interactable = false;

            if (_settingsButton.TryGetComponent(out Button settingsButton))
                settingsButton.interactable = false;
        }

        private void OnDisable()
        {
            if (_leaderboardButton.TryGetComponent(out Button button))
                button.interactable = true;

            if (_soundsButton.TryGetComponent(out Button soundsButton))
                soundsButton.interactable = true;

            if (_playButton.TryGetComponent(out Button playButton))
                playButton.interactable = true;

            if (_settingsButton.TryGetComponent(out Button settingsButton))
                settingsButton.interactable = true;
        }
    }
}