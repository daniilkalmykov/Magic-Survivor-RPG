using UI.Views;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels.Education
{
    [RequireComponent(typeof(Button))]
    public abstract class EducationPanel : MonoBehaviour
    {
        [SerializeField] private TimerView _timerView;
        
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        protected virtual void OnEnable()
        {
            Time.timeScale = 0;
            
            _button.onClick.AddListener(OnCLick);
            _timerView.gameObject.SetActive(false);
        }

        protected virtual void OnDisable()
        {
            Time.timeScale = 1;
            
            _button.onClick.RemoveListener(OnCLick);
            _timerView.gameObject.SetActive(transform);
        }

        private void Update()
        {
            Time.timeScale = 0;
        }

        private void OnCLick()
        {
            gameObject.SetActive(false);
        }
    }
}