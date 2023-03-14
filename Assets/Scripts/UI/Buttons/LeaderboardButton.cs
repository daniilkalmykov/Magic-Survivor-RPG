using UI.Views;
using UnityEngine;

namespace UI.Buttons
{
    public sealed class LeaderboardButton : GameButton
    {
        [SerializeField] private LeaderboardView _leaderboard;
        
        protected override void OnClick()
        {
            OpenLeaderboard();
        }

        private void OpenLeaderboard()
        {
            _leaderboard.gameObject.SetActive(true);
        }
    }
}