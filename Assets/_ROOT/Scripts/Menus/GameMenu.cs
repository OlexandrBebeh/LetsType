namespace _ROOT.Scripts.Menus
{
    using System;
    using Game;
    using Unity.VisualScripting;
    using UnityEditor;
    using UnityEngine;
    public class GameMenu : MonoBehaviour
    {
        [SerializeField] public GameObject menu;
        
        private bool isStoped;

        private void Awake()
        {
            isStoped = false;
            menu.SetActive(false);
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Escape) && GameController.Instance.GetState() != GameState.menu)
            {
                if (isStoped)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            menu.SetActive(false);
            Time.timeScale = 1f;
            isStoped = false;        
        }

        private void Pause()
        {
            menu.SetActive(true);
            Time.timeScale = 0f;
            isStoped = true;
        }

        public void ExitToMenu()
        {
            Time.timeScale = 1f;
            GameController.Instance.Exit();
            Resume();
        }
        
        public void Exit()
        {
            Time.timeScale = 1f;
            Application.Quit();
        }
    }
}