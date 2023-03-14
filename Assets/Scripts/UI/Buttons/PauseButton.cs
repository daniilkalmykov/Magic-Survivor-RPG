using UI.Panels;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public sealed class PauseButton : GameButton
    {
        [SerializeField] private PausePanel _pausePanel;
        
        private void Start()
        {
            _pausePanel.gameObject.SetActive(false);
        }

        protected override void OnClick()
        {
            Pause();
        }

        private void Pause()
        {
            Time.timeScale = 0;
            _pausePanel.gameObject.SetActive(true);
        }
    }
}
