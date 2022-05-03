using _ROOT.Scripts.Tools;
using UnityEngine;

namespace _ROOT.Scripts.Game
{
    public class GameController : Singleton<GameController>
    {
        [SerializeField] private SceneController sceneController;

        private GameState state;
        
        private int currentLevel;

        public void StartGame()
        {
            sceneController.UnloadMenu();
            sceneController.SwitchToFightScene();
            state = GameState.fight;
        }
        
        public void StartGame(int level)
        {
            sceneController.UnloadMenu();
            sceneController.SwitchToLevelScene(level);
            state = GameState.level;
            currentLevel = level;
        }
        
        public void Exit()
        {
            switch (state)
            {
               case GameState.fight:
                   sceneController.UnloadFightScene();
                   sceneController.SwitchToLevelScene(currentLevel);
                   state = GameState.level;

                   break;
               case GameState.level:
                   sceneController.UnloadLevelScene(currentLevel);
                   sceneController.LoadMenu();
                   state = GameState.menu;

                   break;
               case GameState.menu:
                   sceneController.UnloadLevelScene(currentLevel);
                   sceneController.LoadMenu();
                   state = GameState.load;

                   break;
            }
        }
    }
}