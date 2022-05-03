using _ROOT.Scripts.Game;
using UnityEngine;

namespace _ROOT.Scripts.Menus
{
    public class StartMenu : MonoBehaviour
    {
        public void StartGame()
        {
            GameController.Instance.StartGame();
        }
        
        public void StartGame(int level)
        {
            GameController.Instance.StartGame(level);
        }
    }
}