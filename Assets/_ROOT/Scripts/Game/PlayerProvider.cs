namespace _ROOT.Scripts.Game
{
    using GlobalWorld;
    using Tools;
    using UnityEngine;
    public class PlayerProvider : Singleton<PlayerProvider>
    {
        public Player Player => player == null ? player = FindObjectOfType<Player>() : player;

        private Player player;
    }
}