using UI.Panels;
using UnityEngine;

namespace UI.Buttons
{
    public sealed class VolumeTabButton : GameButton
    {
        [SerializeField] private VolumePanel _volumePanel;
        
        protected override void OnClick()
        {
            OpenVolumePanel();
        }

        private void OpenVolumePanel()
        {
            _volumePanel.gameObject.SetActive(true);
        }
    }
}
