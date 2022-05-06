namespace _ROOT.Scripts.Saves.Level
{
    public class LevelSavable : SavableComponent<LevelSave>
    {
        public static LevelSavable Instance => instance ??= new LevelSavable();
        private static LevelSavable instance;

        public int current_level { get; set; }

        public virtual LevelSave PrepareInitial()
        {
            return new LevelSave()
            {
                current_level = 1
            };
        }

        public override LevelSave Serialize()
        {
            return new LevelSave
            {
                current_level = current_level,
            };
        }

        public override void Deserialize(LevelSave save)
        {
            current_level = save.current_level;
        }
    }
}