using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class CloseButton : GameButton
    {
        [SerializeField] private Image _panel;
        
        protected override void OnClick()
        {
            CloseShop();
        }

        private void CloseShop()
        {
            _panel.gameObject.SetActive(false);
        }
    }
}