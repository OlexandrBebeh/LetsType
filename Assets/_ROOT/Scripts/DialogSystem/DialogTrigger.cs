namespace _ROOT.Scripts.DialogSystem
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Game;
    using GlobalWorld;
    using TMPro;
    using UnityEngine;
    public class DialogTrigger : MonoBehaviour
    {
        [SerializeField] private Dialog dialog;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.gameObject.GetComponentInParent<Player>();
            if (player)
            {
                player.DisableMove();
                dialog.OnDialogEnd += player.SubscribeForMove;
                dialog.OnDialogEnd += GameController.Instance.IsDialog;

                GameController.Instance.IsDialog(true);
                dialog.StartDialog();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var player = other.gameObject.GetComponentInParent<Player>();
            if (player)
            {
                GameController.Instance.IsDialog();
                dialog.OnDialogEnd -= player.SubscribeForMove;
                dialog.OnDialogEnd -= GameController.Instance.IsDialog;
            }
        }

        public void SetDialog(Dialog newDialog)
        {
            dialog = newDialog;
        }
    }
}