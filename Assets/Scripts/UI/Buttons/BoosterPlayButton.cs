using UI.Panels;
using UnityEngine;

namespace UI.Buttons
{
    public class BoosterPlayButton : GameButton
    {
        [SerializeField] private BoostersPanel _boostersPanel;
        
        protected override void OnClick()
        {
            Play();
        }

        private void Play()
        {
            Time.timeScale = 1;
            _boostersPanel.gameObject.SetActive(false);
        }
    }
}