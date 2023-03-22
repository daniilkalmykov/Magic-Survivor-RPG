using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class UpgradedCardsPanel : MonoBehaviour
    {
        [SerializeField] private Image _label;
        
        private void OnEnable()
        {
            _label.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            _label.gameObject.SetActive(false);
        }
    }
}