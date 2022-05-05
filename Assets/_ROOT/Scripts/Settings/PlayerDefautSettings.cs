using System;
using UnityEngine;

namespace _ROOT.Scripts.Settings
{
    [CreateAssetMenu(fileName = nameof(PlayerDefautSettings), menuName = "LetsType/PlayerDefautSettings")]
    public class PlayerDefautSettings : ScriptableObject
    {
        public PlayerDefaut stats;
    }

    [Serializable]
    public class PlayerDefaut
    {
        public int Gold;
        
        public int Range;
        
        public int Hearts;
    }
}