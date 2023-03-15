using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public sealed class CloseButton : GameButton
    {
        [SerializeField] private Image _panel;
        
        protected override void OnClick()
        {
            Close();
        }

        private void Close()
        {
            _panel.gameObject.SetActive(false);
        }
    }
}