namespace _ROOT.Scripts.DialogSystem
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Saves.Player;
    using TMPro;
    using UnityEngine;
    public class DialogWithReward : Dialog
    {
        [SerializeField] private int reward = 20;

        private bool rewardTaken = false;
        public override void PostDialog()
        {
            if (!rewardTaken)
            {
                rewardTaken = true;
                PlayerSavable.Instance.Gold += reward;
            }
        }
    }
}