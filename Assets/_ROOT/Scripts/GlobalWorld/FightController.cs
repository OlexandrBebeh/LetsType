using _ROOT.Scripts.Game;
using _ROOT.Scripts.GlobalWorld.Enemies;
using _ROOT.Scripts.Saves;
using _ROOT.Scripts.Saves.Player;
using _ROOT.Scripts.Tools;
using UnityEngine;

namespace _ROOT.Scripts.GlobalWorld
{
    public class FightController : Singleton<FightController>
    {
        private Enemy enemy;
        
        public void PrepareFight(Enemy enemy)
        {
            this.enemy = enemy;
            GameEvents.OnFightEnd += FightResult;
        }
        
        public string GetEnemyName()
        {
            return enemy.Name;
        }
        
        public void FightResult(FightResults res)
        {
            if (res == FightResults.Win)
            {
                PlayerSavable.Instance.Gold += enemy.Reward;
                enemy.DestroySelf();
            }
            PlayerProvider.Instance.Player.EnableMove();
            
            GameEvents.OnFightEnd -= FightResult;
            GameController.Instance.ExitFight();
            SaveController.Instance.SaveState();

        }
    }
}