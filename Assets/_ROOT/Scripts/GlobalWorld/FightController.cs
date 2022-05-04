using _ROOT.Scripts.Game;
using _ROOT.Scripts.GlobalWorld.Enemies;
using _ROOT.Scripts.Tools;
using UnityEngine;

namespace _ROOT.Scripts.GlobalWorld
{
    public class FightController : Singleton<FightController>
    {
        private Enemy enemy;

        public void SetEnemy(Enemy enemy)
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
                Destroy(enemy.gameObject);
            }
            PlayerProvider.Instance.Player.FightEnd(enemy, res);
            GameEvents.OnFightEnd -= FightResult;
            GameController.Instance.ExitFight();

        }
    }
}