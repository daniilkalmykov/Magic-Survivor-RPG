using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;

namespace YandexSDK
{
    public sealed class Leaderboard : MonoBehaviour
    {
        private const string LeaderboardName = "Score";
        private const int MinPlayersCount = 1;
        private const int MaxPlayersCount = 5;
        
        private readonly List<LeaderboardPlayer> _leaderboardPlayers = new();
        
        public static void AddPlayer(int score)
        {
            if (PlayerAccount.IsAuthorized == false)
                return;
            
            Agava.YandexGames.Leaderboard.GetPlayerEntry(LeaderboardName, _ =>
            {
                Agava.YandexGames.Leaderboard.SetScore(LeaderboardName, score);
            });
        }
        
        public void Fill()
        {
            if(PlayerAccount.IsAuthorized == false)
                return;
            
            Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, result =>
            {
                var results = result.entries.Length;
                results = Mathf.Clamp(results, MinPlayersCount, MaxPlayersCount);

                for (var i = 0; i < results; i++)
                {
                    var score = result.entries[i].score;
                    var playerName = result.entries[i].player.publicName;

                    if (string.IsNullOrEmpty(playerName))
                        playerName = "Anonymous";

                    _leaderboardPlayers.Add(new LeaderboardPlayer(playerName, score));
                }
            });
        }

        public void Clear()
        {
            _leaderboardPlayers.Clear();
        }

        public List<LeaderboardPlayer> GetPlayers()
        {
            return _leaderboardPlayers;
        }
    }
}
