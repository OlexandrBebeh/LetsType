namespace _ROOT.Scripts.Menus
{
    using Game;
    using Saves;
    using Saves.Level;
    using UnityEngine;
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