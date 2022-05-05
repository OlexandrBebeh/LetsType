using System;
using TMPro;
using UnityEngine;

namespace _ROOT.Scripts.DialogSystem
{
    public class DialogSystem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;
        
        [SerializeField] private string[] lines;

        [SerializeField] private float textSpeed;

        private int index;
        private void Start()
        {
            textMeshProUGUI.text = String.Empty;
            StartDialog();
        }

        private void StartDialog()
        {
            index = 0;
        }
    }
}