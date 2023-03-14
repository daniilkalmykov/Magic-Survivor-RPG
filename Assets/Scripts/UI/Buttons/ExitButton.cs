using UnityEngine;

namespace UI.Buttons
{
    public sealed class ExitButton : GameButton
    {
        protected override void OnClick()
        {
            Exit();
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}