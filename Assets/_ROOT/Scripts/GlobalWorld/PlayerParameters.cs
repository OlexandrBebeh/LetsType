using _ROOT.Scripts.Tools;

namespace _ROOT.Scripts.GlobalWorld
{
    public class PlayerParameters : Singleton<PlayerParameters>
    {
        public int MaxHearts { get; set; }

        public int GoldAmount { get; set; }

        public float HitZoneRagius { get; set; }
        
        public bool NeedReadFrom { get; set; }

    }
}