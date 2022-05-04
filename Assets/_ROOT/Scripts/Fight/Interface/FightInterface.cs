using TMPro;
using UnityEngine;

namespace _ROOT.Scripts.Fight.Interface
{
    public class FightInterface : MonoBehaviour
    {
        [SerializeField] private TMP_Text HeartLabel;

        [SerializeField] private TMP_Text WordsLeftPanel;

        [SerializeField] private Character character;
        
        [SerializeField] private UnitSpawner unitSpawner;

        private string WordsLeftFraze;
        private void Start()
        {
            WordsLeftFraze = "Words left: ";
            HeartLabel.SetText(character.hearts.ToString());
            WordsLeftPanel.SetText(WordsLeftFraze + unitSpawner.GetWordsLeft().ToString());
        }

        private void FixedUpdate()
        {
            HeartLabel.SetText(character.hearts.ToString());
            WordsLeftPanel.SetText(WordsLeftFraze + unitSpawner.GetWordsLeft().ToString());

        }
        
    }
}