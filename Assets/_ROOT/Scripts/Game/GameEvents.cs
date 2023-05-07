namespace _ROOT.Scripts.Game
{
    using System;
    using GlobalWorld;
    using GlobalWorld.Enemies;

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