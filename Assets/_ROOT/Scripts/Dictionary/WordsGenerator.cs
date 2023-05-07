namespace _ROOT.Scripts.Dictionary
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using UnityEngine;
    public class WordsGenerator
    {
        private Dictionary<int, List<string>> dictionary = new ();
        
        public WordsGenerator()
        {
            var file = Resources.Load<TextAsset>("words");
 
            IEnumerable<string> lines = file.text.Split("\r\n");

            foreach (var line in lines)
            {
                if (!dictionary.ContainsKey(line.Length))
                {
                    dictionary.Add(line.Length, new List<string>());
                }
                dictionary[line.Length].Add(line.ToLower());
            }
        }

        public string GetWord(int length)
        {
            return dictionary[length][(int)(Random.value * dictionary[length].Count) % dictionary[length].Count];
        }
        
    }
}