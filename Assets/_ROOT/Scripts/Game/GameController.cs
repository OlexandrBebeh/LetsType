namespace _ROOT.Scripts.Game
{
    using System.Threading.Tasks;
    using GlobalWorld;
    using GlobalWorld.Enemies;
    using Saves;
    using Saves.Level;
    using Tools;
    using UnityEngine;
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

        public void LoadMenu()
        {
            sceneController.LoadMenu();
            state = GameState.menu;
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

        public void IsDialog(bool inDialog = false)
        {
            if (inDialog)
            {
                state = GameState.dialog;
            }
            else
            {
                state = GameState.level;
            }
        }
    }
}