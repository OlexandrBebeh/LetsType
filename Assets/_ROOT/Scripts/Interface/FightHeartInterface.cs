using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _ROOT.Scripts.Interface
{
    public class FightHeartInterface : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;
        
        [SerializeField] private Character character;
        private void Start()
        {
            label.SetText(character.hearts.ToString());
        }

        private void FixedUpdate()
        {
            label.SetText(character.hearts.ToString());
        }
        
    }
}