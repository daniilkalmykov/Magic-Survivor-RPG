using System;

namespace GameLogic
{
    public sealed class Timer
    {
        private const int SecondsInMinute = 60;
        
        private float _time;
        private float _highestScore;

        public static int ScoreSeconds { get; private set; }
        public static int ScoreMinutes { get; private set; }
        
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
            ScoreSeconds = Seconds;
            ScoreMinutes = Minutes;
        }
    }
}