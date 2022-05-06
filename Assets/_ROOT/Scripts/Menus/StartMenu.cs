using _ROOT.Scripts.Game;
using _ROOT.Scripts.Saves;
using _ROOT.Scripts.Saves.Level;
using UnityEngine;

namespace _ROOT.Scripts.Menus
{
    public class StartMenu : MonoBehaviour
    {
        public void ContinueGame()
        {
            SaveController.Instance.LoadSave();
            StartGame();
        }
        
        public void StartGame()
        {
            GameController.Instance.StartGame();
        }
        
        public void StartNewGame()
        {
            SaveController.Instance.PrepareSave(true);
            ContinueGame();
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}