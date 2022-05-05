using System;
using System.Collections.Generic;
using _ROOT.Scripts.Saves.Player;

namespace _ROOT.Scripts.Saves
{
    public class SaveModel
    {
        public Header header;

        public PlayerSave PlayerSave;
        
        public LevelSave LevelSave;
    }

    public class LevelSave : SaveComponent
    {
    }

    public class Header
    {
        public DateTime time;

        public int version;
    }
}