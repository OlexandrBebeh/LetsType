namespace _ROOT.Scripts.Saves
{
    using System;
    using Level;
    using Player;
    public class SaveModel
    {
        public Header header;

        public PlayerSave PlayerSave;
        
        public LevelSave LevelSave;
    }

    public class Header
    {
        public DateTime time;

        public int version;
    }
}