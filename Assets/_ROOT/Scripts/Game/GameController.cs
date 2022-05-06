using System.Threading.Tasks;
using _ROOT.Scripts.GlobalWorld;
using _ROOT.Scripts.GlobalWorld.Enemies;
using _ROOT.Scripts.Saves;
using _ROOT.Scripts.Saves.Level;
using _ROOT.Scripts.Tools;
using UnityEngine;

namespace _ROOT.Scripts.Game
{
    public class GameController : Singleton<GameController>
    {
        [SerializeField] private SceneController sceneController;

        [SerializeField] private CameraController cameraController;

        [SerializeField] private PlayerProvider playerProvider;
        
        private GameState state;
        
        public GameState GetState()
        {
            return state;
        }

        public void StartFight(Enemy enemy)
        {
            sceneController.SwitchToFightScene();
            cameraController.DisableWorldCamera();
            FightController.Instance.PrepareFight(enemy);
            state = GameState.fight;
        }
        
        public void StartGame()
        {
            sceneController.UnloadMenu();
            sceneController.SwitchToLevelScene(LevelSavable.Instance.current_level);
            state = GameState.level;
        }
        
        public void StartNextLevel()
        {
            sceneController.UnloadLevelScene(LevelSavable.Instance.current_level);
            LevelSavable.Instance.current_level++;
            sceneController.SwitchToLevelScene(LevelSavable.Instance.current_level);
            SaveController.Instance.SaveState();

        }
        
        public void Exit()
        {
            switch (state)
            {
               case GameState.fight:
                   sceneController.UnloadFightScene();
                   cameraController.EnableWorldCamera();
                   state = GameState.level;

                   break;
               case GameState.level:
                   sceneController.UnloadLevelScene(LevelSavable.Instance.current_level);
                   sceneController.LoadMenu();
                   state = GameState.menu;

                   break;
               case GameState.menu:
                   sceneController.UnloadMenu();
                   state = GameState.load;

                   break;
            }
        }

        public void ExitFight()
        {
            sceneController.UnloadFightScene();
            cameraController.EnableWorldCamera();
            state = GameState.level;
        }
    }
}