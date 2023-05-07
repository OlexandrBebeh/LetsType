namespace _ROOT.Scripts.GlobalWorld
{
    using Tools;
    public class PlayerParameters : Singleton<PlayerParameters>
    {
        public int MaxHearts { get; set; }

        public int GoldAmount { get; set; }

        public float HitZoneRagius { get; set; }
        
        public bool NeedReadFrom { get; set; }

    }
}