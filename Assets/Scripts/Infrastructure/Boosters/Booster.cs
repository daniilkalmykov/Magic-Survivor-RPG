using UI.Panels;
using UnityEngine;
using UnityEngine.UI;
using YandexSDK;

namespace Infrastructure.Boosters
{
    [RequireComponent(typeof(Button))]
    public abstract class Booster : MonoBehaviour
    {
        [SerializeField] private AdShower _adShower;
        [SerializeField] private BoostersPanel _boostersPanel;
        
        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        protected void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        protected void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        protected virtual void OnClick()
        {
            _boostersPanel.gameObject.SetActive(false);
            _adShower.Show();
        }
    }
}