using UnityEngine;

namespace Player
{
    public sealed class PlayerExperience : MonoBehaviour
    {
        [SerializeField] private int _borderExperienceToNextLevel;

        private int _currentExperience;
        private int _experienceToNextLevel;
        private int _level = 1;
        private int _startBorderExperience;

        private void Awake()
        {
            _startBorderExperience = _borderExperienceToNextLevel;
            _experienceToNextLevel = _borderExperienceToNextLevel;
        }

        public void AddExperience(int experience)
        {
            _currentExperience += experience;

            if (_currentExperience >= _experienceToNextLevel)
            {
                _level++;
                _currentExperience = 0;

                _borderExperienceToNextLevel += _startBorderExperience;
                _experienceToNextLevel += _borderExperienceToNextLevel;
            }
        }
    }
}