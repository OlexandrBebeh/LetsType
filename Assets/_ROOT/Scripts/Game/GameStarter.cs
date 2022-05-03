using _ROOT.Scripts.Tools;
using UnityEngine;

namespace _ROOT.Scripts.Game
{
    public class GameStarter : Singleton<GameStarter>
    {
        [SerializeField] private SceneController sceneController;

        public void StartGame()
        {
            sceneController.UnloadMenu();
            sceneController.SwitchToFightScene();
            
        }
    }
}