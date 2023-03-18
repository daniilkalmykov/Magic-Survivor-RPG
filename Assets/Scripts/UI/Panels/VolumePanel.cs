using UnityEngine;

namespace UI.Panels
{
    public sealed class VolumePanel : MonoBehaviour
    {
        [SerializeField] private LanguagePanel _languagePanel;
        
        private void OnEnable()
        {
            _languagePanel.gameObject.SetActive(false);
        }
    }
}