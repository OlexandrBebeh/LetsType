﻿using System.Threading.Tasks;
using _ROOT.Scripts.GlobalWorld;
using _ROOT.Scripts.GlobalWorld.Enemies;
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
        
        private int currentLevel;

        public void StartGame()
        {
            sceneController.UnloadMenu();
            sceneController.SwitchToFightScene();
            state = GameState.fight;
        }
        
        public void StartFight()
        {
            sceneController.SwitchToFightScene();
            cameraController.DisableWorldCamera();
            state = GameState.fight;
        }
        
        public void StartFight(Enemy enemy)
        {
            sceneController.SwitchToFightScene();
            cameraController.DisableWorldCamera();
            FightController.Instance.SetEnemy(enemy);
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
                   cameraController.EnableWorldCamera();
                   state = GameState.level;

                   break;
               case GameState.level:
                   sceneController.UnloadLevelScene(currentLevel);
                   sceneController.LoadMenu();
                   state = GameState.menu;

                   break;
               case GameState.menu:
                   sceneController.UnloadMenu();
                   state = GameState.load;

                   break;
            }
        }
    }
}