using GameLogic;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class TimerView : MonoBehaviour
    {
        private TMP_Text _time;
        private Timer _timer;

        private void Awake()
        {
            _time = GetComponent<TMP_Text>();
            _timer = new Timer();
        }

        private void Update()
        {
            _timer.Update(Time.deltaTime * 10);

            _time.text = _timer.Seconds.ToString().Length == 1
                ? $"{_timer.Minutes} : 0{_timer.Seconds}"
                : $"{_timer.Minutes} : {_timer.Seconds}";
        }
    }
}