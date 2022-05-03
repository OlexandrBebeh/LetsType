using _ROOT.Scripts.Game;
using UnityEngine;

namespace _ROOT.Scripts.Menus
{
    public class StartMenu : MonoBehaviour
    {
        public void StartGame()
        {
            GameStarter.Instance.StartGame();
        }
    }
}