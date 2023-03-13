using UnityEngine;

namespace UI
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
            _boostersPanel.gameObject.SetActive(false);
        }
    }
}