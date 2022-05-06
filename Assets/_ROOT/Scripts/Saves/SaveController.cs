using System;
using _ROOT.Scripts.Saves.Player;
using _ROOT.Scripts.Saves.Level;

namespace _ROOT.Scripts.Saves
{
    public class SaveController
    {
        public static SaveController Instance => instance ??= new SaveController();
        private static SaveController instance;

        private readonly SaveWorker saveWorker;

        private SaveController()
        {
            saveWorker = new SaveWorker();
        }

        public void LoadSave()
        {
            var saveModel = saveWorker.Load();
            PlayerSavable.Instance.Deserialize(saveModel.PlayerSave);
            LevelSavable.Instance.Deserialize(saveModel.LevelSave);
        }

        public void SaveState()
        {
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
    }
}