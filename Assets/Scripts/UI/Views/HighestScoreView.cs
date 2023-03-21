using Constants;
using TMPro;
using UnityEngine;

namespace UI.Views
{
    [RequireComponent(typeof(TMP_Text))]
    public sealed class HighestScoreView : MonoBehaviour
    {
        private TMP_Text _score;

        private void Awake()
        {
            _score = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            if (string.IsNullOrEmpty(PlayerPrefs.GetString(PlayerPrefsConstants.Record)))
                gameObject.SetActive(false);

            _score.text = PlayerPrefs.GetString(PlayerPrefsConstants.Record);
            
            PlayerPrefs.Save();
        }
    }
}