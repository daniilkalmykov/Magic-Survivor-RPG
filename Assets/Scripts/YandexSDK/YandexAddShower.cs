/*using Agava.YandexGames;
using UnityEngine;

namespace YandexSDK
{
    public sealed class YandexAddShower
    {
        [SerializeField] private AudioListener _audioListener;  
        [Sf]
        
        public static void ShowVideoAdd()
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
        }
    }
}*/