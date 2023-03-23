using System;
using GameLogic;
using UnityEngine;

namespace YandexSDK
{
    public abstract class AdShower : MonoBehaviour
    {
        [SerializeField] private AudioListener _audioListener;

        public abstract void Show();

        protected void OnOpenCallBack()
        {
            Time.timeScale = 0;
            
            _audioListener.enabled = false;
            SoundMuter.Mute();
        }
        
        protected void OnCloseCallBack()
        {
            Time.timeScale = 1;
            
            _audioListener.enabled = true;
            SoundMuter.Unmute();
        }

        protected void OnCloseCallBack(bool state)
        {
            if(state)
                return;
            
            Time.timeScale = 1;
            
            _audioListener.enabled = true;
            SoundMuter.Unmute();
        }
    }
}