namespace _ROOT.Scripts.Saves.Level
{
    using System;
    public class LevelSavable : SavableComponent<LevelSave>
    {
        public static LevelSavable Instance => instance ??= new LevelSavable();
        private static LevelSavable instance;

        public int current_level { get; set; }

        public int level_seed { get; set; }

        public virtual LevelSave PrepareInitial()
        {
            return new LevelSave()
            {
                current_level = 1,
                level_seed = new Random().Next()
            };
        }

        public override LevelSave Serialize()
        {
            return new LevelSave
            {
                current_level = current_level,
                level_seed = level_seed,
            };
        }

        public override void Deserialize(LevelSave save)
        {
            current_level = save.current_level;
            level_seed = save.level_seed;
        }
    }
}