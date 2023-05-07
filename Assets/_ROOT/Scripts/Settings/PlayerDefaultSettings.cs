namespace _ROOT.Scripts.Settings
{
    using System;
    using UnityEngine;
    
    [CreateAssetMenu(fileName = nameof(PlayerDefaultSettings), menuName = "LetsType/PlayerDefautSettings")]
    public class PlayerDefaultSettings : ScriptableObject
    {
        public PlayerDefault stats;
    }

    [Serializable]
    public class PlayerDefault
    {
        public int Gold;
        
        public int Range;
        
        public int Hearts;
    }
}