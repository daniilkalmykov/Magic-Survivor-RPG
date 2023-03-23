using System;
using UnityEngine;

namespace Player
{
    public sealed class PlayerExperience : MonoBehaviour
    {
        [SerializeField] private int _borderExperienceToNextLevel;
        [SerializeField] private ParticleSystem _buff;
        [SerializeField] private AudioSource _buffSound;

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
            InitActions();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
                AddExperience(ExperienceToNextLevel);
        }

        public void AddExperience(int experience)
        {
            CurrentExperience += experience;
            Instantiate(_buff, transform.position, Quaternion.identity, transform);
            
            _buffSound.Play();
            
            if (CurrentExperience >= ExperienceToNextLevel)
            {
                Level++;
                CurrentExperience = 0;

                ExperienceToNextLevel += _borderExperienceToNextLevel;
                
                LevelChanged?.Invoke();
            }
            
            ExperienceChanged?.Invoke(CurrentExperience, ExperienceToNextLevel);
        }

        public void InitActions()
        {
            LevelChanged?.Invoke();
            ExperienceChanged?.Invoke(CurrentExperience, ExperienceToNextLevel);
        }
    }
}