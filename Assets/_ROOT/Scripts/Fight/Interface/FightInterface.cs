namespace _ROOT.Scripts.Fight.Interface
{
    using TMPro;
    using UnityEngine;
    public class FightInterface : MonoBehaviour
    {
        [SerializeField] private TMP_Text HeartLabel;

        [SerializeField] private TMP_Text WordsLeftPanel;

        [SerializeField] private TMP_Text CharactersLeftPanel;
        
        [SerializeField] private Character character;
        
        [SerializeField] private UnitSpawner unitSpawner;

        private string WordsLeftFraze;
        private void Start()
        {
            WordsLeftFraze = "Words left: ";
            HeartLabel.SetText(character.hearts.ToString());
            WordsLeftPanel.SetText(WordsLeftFraze + unitSpawner.GetWordsLeft());
            CharactersLeftPanel.SetText(unitSpawner.GetCharactersLeft().ToString());
        }

        private void FixedUpdate()
        {
            HeartLabel.SetText(character.hearts.ToString());
            WordsLeftPanel.SetText(WordsLeftFraze + unitSpawner.GetWordsLeft());
            CharactersLeftPanel.SetText(unitSpawner.GetCharactersLeft().ToString());
        }
        
    }
}