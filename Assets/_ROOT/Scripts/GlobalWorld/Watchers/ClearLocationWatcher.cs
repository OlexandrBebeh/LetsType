using System;
using System.Collections.Generic;
using _ROOT.Scripts.DialogSystem;
using _ROOT.Scripts.Game;
using _ROOT.Scripts.GlobalWorld.Enemies;
using _ROOT.Scripts.Saves.Player;
using Unity.VisualScripting;
using UnityEngine;

namespace _ROOT.Scripts.GlobalWorld
{
    public class ClearLocationWatcher : Watcher
    {
        [SerializeField] List<GameObject> objectsToDestroy;

        [SerializeField] private Dialog dialogForMission;

        [SerializeField] private DialogWithReward dialogForComplete;
        
        [SerializeField] private DialogTrigger dialogTrigger;

        private bool isQuestCompleted;

        private void Awake()
        {
            isQuestCompleted = false;
            GameEvents.OnEnemySlayed += DoOtherStuff;
        }

        public void DoOtherStuff(Enemy enemy)
        {
            if (!isQuestCompleted)
            {
                var itemToRemove = objectsToDestroy.Find(obj => GameObject.ReferenceEquals( obj, enemy.gameObject));
                if (itemToRemove)
                {
                    objectsToDestroy.Remove(itemToRemove);
                }
                
                if (IsMissionComplete())
                {
                    dialogTrigger.SetDialog(dialogForComplete);
                    isQuestCompleted = true;
                    GameEvents.OnEnemySlayed -= DoOtherStuff;
                }
            }
        }

        private bool IsMissionComplete()
        {
            return objectsToDestroy.Count == 0;
        }
    }
}