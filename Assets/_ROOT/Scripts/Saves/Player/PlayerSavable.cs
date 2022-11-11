using _ROOT.Scripts.Settings;
using UnityEngine;

namespace _ROOT.Scripts.Saves.Player
{
    public class PlayerSavable : SavableComponent<PlayerSave>
    {
        public static PlayerSavable Instance => instance ??= new PlayerSavable();
        private static PlayerSavable instance;

        public int Gold { get; set; }
        public int Range { get; set; }
        public int Hearts { get; set; }

        public virtual PlayerSave PrepareInitial()
        {
            var player = Resources.Load<PlayerDefaultSettings>($"Settings/{nameof(PlayerDefaultSettings)}").stats;
            return new PlayerSave()
            {
                Gold = player.Gold,
                Range = player.Range,
                Hearts = player.Hearts,
            };
        }

        public override PlayerSave Serialize()
        {
            return new PlayerSave
            {
                Gold = Gold,
                Range = Range,
                Hearts = Hearts,
            };
        }

        public override void Deserialize(PlayerSave save)
        {
            Gold = save.Gold;
            Range = save.Range;
            Hearts = save.Hearts;
        }
    }
}