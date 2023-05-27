namespace _ROOT.Scripts.Saves
{
    using System;
    using Player;
    using Level;
    public class SaveController
    {
        public static SaveController Instance => instance ??= new SaveController();
        private static SaveController instance;
        private bool is_demo = false;

        private readonly SaveWorker saveWorker;

        private SaveController()
        {
            saveWorker = new SaveWorker();
        }

        public void LoadSave()
        {
            is_demo = false;
            var saveModel = saveWorker.Load();
            PlayerSavable.Instance.Deserialize(saveModel.PlayerSave);
            LevelSavable.Instance.Deserialize(saveModel.LevelSave);
        }

        public void SaveState()
        {
            if (is_demo)
            {
                return;
            }
            var saveModel = new SaveModel();
            saveModel.header = new Header();
            saveModel.header.time = DateTime.Now;
            saveModel.header.version = 1;
            saveModel.PlayerSave = PlayerSavable.Instance.Serialize();
            saveModel.LevelSave = LevelSavable.Instance.Serialize();
            saveWorker.Save(saveModel);
        }
        
        public void PrepareSave(bool delete = false)
        {
            if (saveWorker.Prepare() || delete)
            {
                var saveModel = new SaveModel();
                saveModel.header = new Header();
                saveModel.header.time = DateTime.Now;
                saveModel.header.version = 1;
                
                saveModel.PlayerSave = PlayerSavable.Instance.PrepareInitial();

                saveModel.LevelSave = LevelSavable.Instance.PrepareInitial();
                saveWorker.Save(saveModel);
            }
        }

        public void PrepareDemo()
        {
            is_demo = true;
            
            var saveModel = saveWorker.LoadDemo();

            PlayerSavable.Instance.Deserialize(saveModel.PlayerSave);
        }
    }
}