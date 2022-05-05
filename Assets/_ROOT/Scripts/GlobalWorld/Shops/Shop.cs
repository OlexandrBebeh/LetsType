﻿using _ROOT.Scripts.Saves.Player;
using TMPro;
using UnityEngine;

namespace _ROOT.Scripts.GlobalWorld.Shops
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] public GameObject OtherGameObject;
        
        [SerializeField] public int basePrice;

        [SerializeField] public int priceMultiplier;

        [SerializeField] public int rangeDelim;
        
        [SerializeField] private TMP_Text HeartLabel;

        [SerializeField] private TMP_Text RangeLablePanel;
        private void Awake()
        {
            OtherGameObject.SetActive(false);
        }

        private void Update()
        {
            HeartLabel.SetText(CalculatePrice(PlayerSavable.Instance.Hearts).ToString());
            RangeLablePanel.SetText(CalculatePrice(PlayerSavable.Instance.Range - rangeDelim).ToString());

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var otherPlayer = other.GetComponentInParent<Player>();
            if (otherPlayer)
            {
                OtherGameObject.SetActive(true);
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            var otherPlayer = other.GetComponentInParent<Player>();
            if (otherPlayer)
            {
                OtherGameObject.SetActive(false);
            }
        }

        public void BuyHeart()
        {
            if (PlayerSavable.Instance.Gold > CalculatePrice(PlayerSavable.Instance.Hearts))
            {
                PlayerSavable.Instance.Gold -= CalculatePrice(PlayerSavable.Instance.Hearts);
                PlayerSavable.Instance.Hearts++;
            }
        }
        
        public void BuyRange()
        {
            if (PlayerSavable.Instance.Gold > CalculatePrice(PlayerSavable.Instance.Range - rangeDelim))
            {
                PlayerSavable.Instance.Gold -= CalculatePrice(PlayerSavable.Instance.Range - rangeDelim);
                PlayerSavable.Instance.Range++;
            }
        }

        public int CalculatePrice(int value)
        {
            return basePrice * value * priceMultiplier;
        }
    }
}