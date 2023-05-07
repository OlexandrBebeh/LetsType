namespace _ROOT.Scripts.GlobalWorld.Interface
{
    using System;
    using Saves.Player;
    using TMPro;
    using UnityEngine;
    public class PlayerInterface : MonoBehaviour
    {
        [SerializeField] private TMP_Text HeartLabel;
        [SerializeField] private TMP_Text GoldLabel;
        [SerializeField] private TMP_Text RangeLabel;

        private void FixedUpdate()
        {
            HeartLabel.SetText(PlayerSavable.Instance.Hearts.ToString());
            GoldLabel.SetText(PlayerSavable.Instance.Gold.ToString());
            RangeLabel.SetText(PlayerSavable.Instance.Range.ToString());

        }
    }
}