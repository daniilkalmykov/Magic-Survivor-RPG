using Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public sealed class PlayButton : GameButton
    {
        protected override void OnClick()
        {
            Play();
        }

        private void Play()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(ScenesNames.Level);
        }
    }
}