using Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Buttons
{
    public sealed class RestartButton : GameButton
    {
        protected override void OnClick()
        {
            Restart();
        }

        private void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(ScenesNames.Level);
        }
    }
}