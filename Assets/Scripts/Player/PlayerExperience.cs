using System;
using UnityEngine;

namespace Player
{
    public sealed class PlayerExperience : MonoBehaviour
    {
        [SerializeField] private int _borderExperienceToNextLevel;

        public event Action LevelChanged;
        public event Action<int, int> ExperienceChanged;
        
        public int CurrentExperience { get; private set; }
        public int Level { get; private set; } = 1;
        public int ExperienceToNextLevel { get; private set; }

        private void Awake()
        {
            ExperienceToNextLevel = _borderExperienceToNextLevel;
        }

        private void Start()
        {
            LevelChanged?.Invoke();
            ExperienceChanged?.Invoke(CurrentExperience, ExperienceToNextLevel);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
                AddExperience(ExperienceToNextLevel);
        }

        public void AddExperience(int experience)
        {
            CurrentExperience += experience;

            if (CurrentExperience >= ExperienceToNextLevel)
            {
                Level++;
                CurrentExperience = 0;

                ExperienceToNextLevel += _borderExperienceToNextLevel;
                
                LevelChanged?.Invoke();
            }
            
            ExperienceChanged?.Invoke(CurrentExperience, ExperienceToNextLevel);
        }
    }
}