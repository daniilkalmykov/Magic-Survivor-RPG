using Constants;
using Player;
using UI.Panels;
using UI.Panels.Education;
using UnityEngine;

namespace GameLogic
{
    public sealed class Education : MonoBehaviour
    {
        private const int PlayingTimesToShowEducation = 1;
        private const int PanelsOpeningTimesToShowEducation = 0;
        
        [SerializeField] private MovementEducationPanel _movementEducationPanel;
        [SerializeField] private ExperienceEducationPanel _experienceEducationPanel;
        [SerializeField] private PlayerExperience _playerExperience;
         
        private int _playingTimes;
        private int _movementEducationPanelOpeningTimes;
        private int _experienceEducationPanelOpeningTimes;

        private void Awake()
        {
            _playingTimes = PlayerPrefs.GetInt(PlayerPrefsConstants.PlayingTimes);
            _playingTimes++;
            
            PlayerPrefs.SetInt(PlayerPrefsConstants.PlayingTimes, _playingTimes);
        }

        private void OnEnable()
        {
            _playerExperience.ExperienceChanged += OnExperienceChanged;
        }

        private void OnDisable()
        {
            _playerExperience.ExperienceChanged -= OnExperienceChanged;
        }

        private void Start()
        {
            if (_playingTimes != PlayingTimesToShowEducation ||
                _movementEducationPanelOpeningTimes != PanelsOpeningTimesToShowEducation)
                return;
            
            _movementEducationPanel.gameObject.SetActive(true);
            _movementEducationPanelOpeningTimes++;
        }
        
        private void OnExperienceChanged(int currentExperience, int maxExperience)
        {
            if (_playingTimes != PlayingTimesToShowEducation ||
                _experienceEducationPanelOpeningTimes != PanelsOpeningTimesToShowEducation)
                return;
            
            _experienceEducationPanel.gameObject.SetActive(true);
            _experienceEducationPanelOpeningTimes++;
        }
    }
}