namespace _ROOT.Scripts.DialogSystem
{
    using System;
    using System.Collections;
    using TMPro;
    using UnityEngine;
    
    ///<summary>
    /// Клас, для поступового виводу тексту для користувача у певне поле
    ///</summary>
    public class Dialog : MonoBehaviour
    {
        ///<summary>
        /// Поле, куди воводиться текст
        ///</summary>
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;
        
        ///<summary>
        /// Увесь текст, поділений на частини
        ///</summary>
        [SerializeField] private string[] lines;

        ///<summary>
        /// Швидкість виводу тексту
        ///</summary>
        [SerializeField] private float textSpeed;
        
        ///<summary>
        /// Функція, яка викликається по завершенню діалогу
        ///</summary>
        public event Action<bool> OnDialogEnd;

        ///<summary>
        /// Індекс нинішньої частини тексту, що виводиться
        ///</summary>
        private int index;
        
        ///<summary>
        /// При створенні об'єкту із цим скриптом, він виставляється неактивним
        ///</summary>
        private void Start()
        {
            gameObject.SetActive(false);
        }
        
        ///<summary>
        /// Поступовий вивід тексту та реакція на ввід користувача
        ///</summary>
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

        ///<summary>
        /// Початок поступового виводу тексту
        ///</summary>
        public void StartDialog()
        {
            textMeshProUGUI.text = String.Empty;
            index = 0;
            gameObject.SetActive(true);
            StartCoroutine(TypeLine());
        }

        ///<summary>
        /// Друк тексту до поля
        ///</summary>
        IEnumerator TypeLine()
        {
            foreach (var c in lines[index].ToCharArray())
            {
                textMeshProUGUI.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        ///<summary>
        /// Перевірка та перехід до друку наступної частини тексту
        ///</summary>
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