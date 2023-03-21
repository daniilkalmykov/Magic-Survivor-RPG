using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels.Education
{
    [RequireComponent(typeof(Button))]
    public abstract class EducationPanel : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            Time.timeScale = 0;
            _button.onClick.AddListener(OnCLick);
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
            _button.onClick.RemoveListener(OnCLick);
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