using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace _ROOT.Scripts.DialogSystem
{
    public class Dialog : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;
        
        [SerializeField] private string[] lines;

        [SerializeField] private float textSpeed;
        public event Action<bool> OnDialogEnd;

        private int index;
        private void Start()
        {
            gameObject.SetActive(false);
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (textMeshProUGUI.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textMeshProUGUI.text = lines[index];
                }
            }
        }

        public void StartDialog()
        {
            textMeshProUGUI.text = String.Empty;
            index = 0;
            gameObject.SetActive(true);
            StartCoroutine(TypeLine());
        }

        IEnumerator TypeLine()
        {
            foreach (var c in lines[index].ToCharArray())
            {
                textMeshProUGUI.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        void NextLine()
        {
            if (index < lines.Length - 1)
            {
                index++;
                textMeshProUGUI.text = String.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                PostDialog();
                OnDialogEnd?.Invoke(false);
                gameObject.SetActive(false);
            }
        }

        public virtual void PostDialog()
        {
            
        }
    }
}