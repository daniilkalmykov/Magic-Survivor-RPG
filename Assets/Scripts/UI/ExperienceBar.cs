using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ExperienceBar : Bar
    {
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _experience;
        [SerializeField] private PlayerExperience _playerExperience;
        
        private void OnEnable()
        {
            _playerExperience.ExperienceChanged += OnValueChanged;
            _playerExperience.LevelChanged += OnLevelChanged;
        }

        private void OnDisable()
        {
            _playerExperience.ExperienceChanged -= OnValueChanged;
            _playerExperience.LevelChanged -= OnLevelChanged;
        }
        
        private void Start()
        {
            SetStartValues(_playerExperience.ExperienceToNextLevel, _playerExperience.CurrentExperience);
        }

        protected override void OnValueChanged(int currentValue, int maxValue)
        {
            base.OnValueChanged(currentValue, maxValue);

            _experience.text = $"{_playerExperience.CurrentExperience} / {_playerExperience.ExperienceToNextLevel}";
        }

        private void OnLevelChanged()
        {
            SetStartValues(_playerExperience.ExperienceToNextLevel, 0);

            _level.text = _playerExperience.Level.ToString();
        }
    }
}