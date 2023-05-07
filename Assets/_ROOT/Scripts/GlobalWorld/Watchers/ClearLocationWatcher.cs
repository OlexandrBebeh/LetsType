namespace _ROOT.Scripts.GlobalWorld
{
    using System;
    using System.Collections.Generic;
    using DialogSystem;
    using Game;
    using GlobalWorld.Enemies;
    using Saves.Player;
    using Unity.VisualScripting;
    using UnityEngine;
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