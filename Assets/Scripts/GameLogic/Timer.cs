using System;
using Constants;
using UnityEngine;

namespace GameLogic
{
    public sealed class Timer
    {
        private const int SecondsInMinute = 60;
            
        private static string s_scoreText;
        
        private float _time;
        private float _highestScore;
        private int _scoreSeconds;
        private int _scoreMinutes;
        
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }

        public void Update(float deltaTime)
        {
            _time += deltaTime;

            Seconds = Convert.ToInt32(_time - SecondsInMinute * Minutes);

            if (Seconds > SecondsInMinute)
                Minutes++;

            if (_highestScore >= _time) 
                return;
            
            _highestScore = _time;
            _scoreSeconds = Seconds;
            _scoreMinutes = Minutes;
            
            s_scoreText = _scoreSeconds.ToString().Length == 1
                ? $"{_scoreMinutes} : 0{_scoreSeconds}"
                : $"{_scoreMinutes} : {_scoreSeconds}";

            PlayerPrefs.SetString(PlayerPrefsConstants.Record, s_scoreText);
            PlayerPrefs.Save();
        }
    }
}