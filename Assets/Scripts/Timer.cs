using System;

public class Timer
{
    private const int SecondsInMinute = 60;

    private float _time;
    
    public int Minutes { get; private set; }
    public int Seconds { get; private set; }

    public void Update(float deltaTime)
    {
        _time += deltaTime;

        Seconds = Convert.ToInt32(_time - SecondsInMinute * Minutes);

        if (Seconds > SecondsInMinute)
            Minutes++;
    }
}