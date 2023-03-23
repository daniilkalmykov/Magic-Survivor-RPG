using UI.Bars;
using UI.Buttons;
using UI.Views;
using UnityEngine;

namespace UI.Panels
{
    public sealed class BoostersPanel : MonoBehaviour
    {
        [SerializeField] private GameLogic.Education _education;
        [SerializeField] private TimerView _timerView;
        [SerializeField] private ExperienceBar _experienceBar;
        [SerializeField] private PauseButton _pauseButton;
        
        private void OnEnable()
        {
            Time.timeScale = 0;
            
            _education.gameObject.SetActive(false);
            _timerView.gameObject.SetActive(false);
            _experienceBar.gameObject.SetActive(false);
            _pauseButton.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
            
            _education.gameObject.SetActive(true);
            _timerView.gameObject.SetActive(true);
            _experienceBar.gameObject.SetActive(true);
            _pauseButton.gameObject.SetActive(true);
        }
    }
}
