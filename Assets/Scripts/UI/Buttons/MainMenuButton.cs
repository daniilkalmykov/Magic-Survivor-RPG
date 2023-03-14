using Constants;
using UnityEngine.SceneManagement;

namespace UI.Buttons
{
    public sealed class MainMenuButton : GameButton
    {
        protected override void OnClick()
        {
            LoadMainMenuScene();
        }

        private void LoadMainMenuScene()
        {
            SceneManager.LoadScene(ScenesNames.MainMenu);
        }
    }
}