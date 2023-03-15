using System;
using Constants;
using UnityEngine;
using YandexSDK;
using Debug = UnityEngine.Debug;

namespace GameLogic
{
    public sealed class Timer
    {
        private const int SecondsInMinute = 60;
        
        private static float s_highestScore;
        private static string s_scoreText;
            
        private float _time;
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

            if (s_highestScore >= _time) 
                return;
            
            s_highestScore = _time;
            _scoreSeconds = Seconds;
            _scoreMinutes = Minutes;

            s_scoreText = _scoreSeconds.ToString().Length == 1
                ? $"{_scoreMinutes} : 0{_scoreSeconds}"
                : $"{_scoreMinutes} : {_scoreSeconds}";
        }

        public static string ConvertIntToTime(int value)
        {
            var minutes = value / SecondsInMinute;
            var seconds = value - minutes;

            return seconds.ToString().Length == 1 ? $"{minutes} : 0{seconds}" : $"{minutes} : {seconds}";
        }

        public static void SaveScore()
        {
            PlayerPrefs.SetString(PlayerPrefsConstants.Record, s_scoreText);
            PlayerPrefs.Save();

            Leaderboard.AddPlayer(Convert.ToInt32(s_highestScore));
        }
    }
}