using UI.Views;
using UnityEngine;

namespace UI.Panels
{
    public sealed class BoostersPanel : MonoBehaviour
    {
        [SerializeField] private GameLogic.Education _education;
        [SerializeField] private TimerView _timerView;
        
        private void OnEnable()
        {
            Time.timeScale = 0;
            
            _education.gameObject.SetActive(false);
            _timerView.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
            
            _education.gameObject.SetActive(true);
            _timerView.gameObject.SetActive(true);
        }
    }
}
