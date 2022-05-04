using _ROOT.Scripts.Tools;

namespace _ROOT.Scripts.GlobalWorld
{
    public class PlayerParameters : Singleton<PlayerParameters>
    {
        private int MaxHearts;
        
        private int GoldAmount;

        private float HitZoneRagius;
        
        private FightResults LastFightResult;


        public void SetMaxHearts(int hearts)
        {
            MaxHearts = hearts;
        }
        
        public int GetMaxHearts()
        {
            return MaxHearts;
        }
        
        public void SetGoldAmount(int gold)
        {
            GoldAmount = gold;
        }
        
        public int GetGoldAmount()
        {
            return GoldAmount;
        }
        
        public void SetHitZoneRadius(float radius)
        {
            HitZoneRagius = radius;
        }
        
        public float GetHitZoneRadius()
        {
            return HitZoneRagius;
        }
        
        public void SetFightResult(FightResults res)
        {
            LastFightResult = res;
        }
        
        public FightResults GetFightResult()
        {
            return LastFightResult;
        }
    }
}