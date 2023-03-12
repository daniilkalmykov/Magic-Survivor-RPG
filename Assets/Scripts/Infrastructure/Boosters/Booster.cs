using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Boosters
{
    [RequireComponent(typeof(Button))]
    public abstract class Booster : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        protected virtual void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        protected virtual void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        protected abstract void OnClick();
    }
}