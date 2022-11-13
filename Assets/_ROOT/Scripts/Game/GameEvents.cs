using System;
using _ROOT.Scripts.GlobalWorld;
using _ROOT.Scripts.GlobalWorld.Enemies;

namespace _ROOT.Scripts.Game
{
    public static class GameEvents
    {
        public static event Action<string> OnFightStart;
        
        public static event Action<Enemy> OnEnemySlayed;

        public static event Action<FightResults> OnFightEnd;

        public static void StartFightEndEvent(FightResults res)
        {
            OnFightEnd?.Invoke(res);
        }
        
        public static void SlayedEnemyEvent(Enemy enemy)
        {
            OnEnemySlayed?.Invoke(enemy);
        }
    }
}