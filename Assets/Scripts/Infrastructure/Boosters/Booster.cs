using Agava.YandexGames;
using UI.Panels;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Boosters
{
    [RequireComponent(typeof(Button))]
    public abstract class Booster : MonoBehaviour
    {
        [SerializeField] private AudioListener _audioListener;
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

        protected abstract void OnRewardedCallBack();
        
        private void OnClick()
        {
            VideoAd.Show(OnRewardedOpenCallBack, OnRewardedCloseCallBack, OnRewardedCallBack);
        }

        private void OnRewardedOpenCallBack()
        {
            Time.timeScale = 0;
            _audioListener.enabled = false;
        }

        private void OnRewardedCloseCallBack()
        {
            Time.timeScale = 1;
            _audioListener.enabled = true;
            _boostersPanel.gameObject.SetActive(false);
        }
    }
}