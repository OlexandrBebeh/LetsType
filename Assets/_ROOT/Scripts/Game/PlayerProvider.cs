using _ROOT.Scripts.GlobalWorld;
using _ROOT.Scripts.Tools;
using UnityEngine;

namespace _ROOT.Scripts.Game
{
    public class PlayerProvider : Singleton<PlayerProvider>
    {
        public Player Player => player == null ? player = FindObjectOfType<Player>() : player;

        private Player player;
    }
}