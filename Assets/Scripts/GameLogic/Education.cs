using Constants;
using UI.Panels.Education;
using UnityEngine;

namespace GameLogic
{
    public sealed class Education : MonoBehaviour
    {
        private const int PlayingTimesToShowEducation = 1;
        private const int PanelsOpeningTimesToShowMovementEducation = 0;
        
        [SerializeField] private MovementEducationPanel _movementEducationPanel;
         
        private int _playingTimes;
        private int _movementEducationPanelOpeningTimes;
        private int _experienceEducationPanelOpeningTimes;

        private void Awake()
        {
            _playingTimes = PlayerPrefs.GetInt(PlayerPrefsConstants.PlayingTimes);
            _playingTimes++;
            
            PlayerPrefs.SetInt(PlayerPrefsConstants.PlayingTimes, _playingTimes);
        }

        private void Start()
        {
            if (_playingTimes != PlayingTimesToShowEducation ||
                _movementEducationPanelOpeningTimes != PanelsOpeningTimesToShowMovementEducation)
                return;
            
            _movementEducationPanel.gameObject.SetActive(true);
            _movementEducationPanelOpeningTimes++;
        }
    }
}