using System.IO;
using System.Linq;
using _ROOT.Scripts.Saves.Player;
using Newtonsoft.Json;
using UnityEngine;

namespace _ROOT.Scripts.Saves
{
    public class SaveWorker
    {
        private const string Path = "save.dat";

        private string FullPath => $"{Application.persistentDataPath}/{Path}";
        
        public void Save(SaveModel saveModel)
        {
            var obj = JsonConvert.SerializeObject(saveModel);
            File.WriteAllText(FullPath, obj);
        }

        public SaveModel Load()
        {
            var content = File.ReadAllText(FullPath);
            var saveModel = JsonConvert.DeserializeObject<SaveModel>(content);
            return saveModel;
        }

        public bool Prepare()
        {
            if (File.Exists(FullPath))
            {
                return false;
            }
            return true;
        }
    }
}