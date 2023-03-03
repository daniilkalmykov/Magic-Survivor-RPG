using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Slider))]
    public abstract class Bar : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Slider _slider;
        private Coroutine _coroutine;    
    
        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }
        
        protected void SetStartValues(int maxValue, int currentValue)
        {
            _slider.maxValue = maxValue;
            _slider.value = currentValue;
        }
    
        protected virtual void OnValueChanged(int currentValue, int maxValue)
        {
            _slider.maxValue = maxValue;
            
            if (_coroutine != null) 
                StopCoroutine(_coroutine);
            
            _coroutine = StartCoroutine(ChangeSliderValue(currentValue));
        }

        private IEnumerator ChangeSliderValue(int currentValue)
        {
            while (_slider.value != currentValue)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, currentValue, Time.deltaTime * _speed);

                yield return null;
            }
        }
    }
}