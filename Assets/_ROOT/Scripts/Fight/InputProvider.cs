namespace _ROOT.Scripts.Fight
{
    using System;
    using System.Linq;
    using UnityEngine;
    public class InputProvider : MonoBehaviour
    {
        public event Action<char> OnInput;

        private readonly char[] excludeChars = {'\b', '\n', ' '};

        private void Update()
        {
            var inputString = Input.inputString;
            foreach (var inputChar in inputString)
            {
                if (excludeChars.All(c => c != inputChar))
                {
                    OnInput?.Invoke(inputChar);
                }
            }
        }
    }
}