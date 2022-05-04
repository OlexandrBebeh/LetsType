using System;
using TMPro;
using UnityEngine;

namespace _ROOT.Scripts.Fight
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;

        [SerializeField] private InputProvider inputProvider;

        public event Action<Unit> OnDeath;


        public char TargetChar { get; private set; }

        private Vector3 Target;

        private bool isActive = false;

        public void Init(char targetChar, InputProvider inputProvider, Vector3 target)
        {
            TargetChar = targetChar;
            this.inputProvider = inputProvider;
            inputProvider.OnInput += OnInput;
            label.SetText(targetChar.ToString());
            label.faceColor = Color.red;
            Target = target;
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

        public void Die()
        {
            OnDeath?.Invoke(this);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            inputProvider.OnInput -= OnInput;
        }

        public Vector3 GetTarget()
        {
            return Target;
        }
    }
}