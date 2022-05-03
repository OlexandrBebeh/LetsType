using System;
using TMPro;
using UnityEngine;

namespace _ROOT.Scripts
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;

        private bool isActive = false;
        public char TargetChar { get; private set; }

        [SerializeField]
        private InputProvider inputProvider;
        
        public void Init(char targetChar, InputProvider inputProvider)
        {
            TargetChar = targetChar;
            this.inputProvider = inputProvider;
            inputProvider.OnInput += OnInput;
            label.SetText(targetChar.ToString());
            label.faceColor = Color.red;
        }

        public void MakeAvailable()
        {
            isActive = true;
            label.faceColor = Color.blue;
        }
        

        private void OnInput(char inputChar)
        {
            if (inputChar == TargetChar && isActive)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            inputProvider.OnInput -= OnInput;
        }
    }
}