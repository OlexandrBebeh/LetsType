using System;
using _ROOT.Scripts.GlobalWorld;

namespace _ROOT.Scripts.Game
{
    public static class GameEvents
    {
        public static event Action<string> OnFightStart;

        public static event Action<FightResults> OnFightEnd;

        public static void StartFightEndEvent(FightResults res)
        {
            OnFightEnd?.Invoke(res);
        }
        
    }
}