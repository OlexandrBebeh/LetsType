﻿namespace _ROOT.Scripts.GlobalWorld
{
    using System;
    using Game;
    using Saves.Player;
    using TMPro;
    using UnityEngine;
    public class NextLevelController : MonoBehaviour
    {
        [SerializeField] public GameObject plateGameObject;

        [SerializeField] private int Price;
        
        [SerializeField] private TMP_Text PriceLabel;

        private void Awake()
        {
            plateGameObject.SetActive(false);
        }
        
        private void FixedUpdate()
        {
            PriceLabel.SetText(Price.ToString());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var otherPlayer = other.GetComponentInParent<Player>();
            if (otherPlayer)
            {
                plateGameObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var otherPlayer = other.GetComponentInParent<Player>();
            if (otherPlayer)
            {
                plateGameObject.SetActive(false);
            }
        }

        public void GoToNextLevel()
        {
            if (PlayerSavable.Instance.Gold >= Price)
            {
                PlayerSavable.Instance.Gold -= Price;
                GameController.Instance.StartNextLevel();
            }
        }
    }
}