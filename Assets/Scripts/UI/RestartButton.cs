using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}