using UnityEngine;

namespace UI.Panels
{
    public sealed class BoostersPanel : MonoBehaviour
    {
        [SerializeField] private GameLogic.Education _education;
        
        private void OnEnable()
        {
            Time.timeScale = 0;
            _education.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
            _education.gameObject.SetActive(true);
        }
    }
}
