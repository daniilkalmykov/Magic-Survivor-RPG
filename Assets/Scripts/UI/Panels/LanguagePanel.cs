using UnityEngine;

namespace UI.Panels
{
    public sealed class LanguagePanel : MonoBehaviour
    {
        [SerializeField] private VolumePanel _volumePanel;

        private void OnEnable()
        {
            _volumePanel.gameObject.SetActive(false);
        }
    }
}