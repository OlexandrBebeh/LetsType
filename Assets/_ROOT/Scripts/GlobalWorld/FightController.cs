namespace _ROOT.Scripts.GlobalWorld
{
    using Game;
    using GlobalWorld.Enemies;
    using Saves;
    using Saves.Player;
    using Tools;
    using UnityEngine;
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
        
        public int GetEnemyLevel()
        {
            return enemy.level;
        }
        public void FightResult(FightResults res)
        {
            if (res == FightResults.Win)
            {
                PlayerSavable.Instance.Gold += enemy.Reward;
                GameEvents.SlayedEnemyEvent(enemy);
                enemy.DestroySelf();
            }
            PlayerProvider.Instance.Player.EnableMove();
            
            GameEvents.OnFightEnd -= FightResult;
            GameController.Instance.ExitFight();
        }
    }
}