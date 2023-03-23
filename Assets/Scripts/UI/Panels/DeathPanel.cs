using UI.Views;
using UnityEngine;

namespace UI.Panels
{
    public sealed class DeathPanel : MonoBehaviour
    {
        [SerializeField] private TimerView _timerView;
    
        private void OnEnable()
        {
            Time.timeScale = 0;
            
            _timerView.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            Time.timeScale = 1;

            _timerView.gameObject.SetActive(true);
        }

        private void Update()
        {
            Time.timeScale = 0;
        }
    }
}