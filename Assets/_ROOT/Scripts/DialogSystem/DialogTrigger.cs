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
    
    ///<summary>
    /// Клас, який реагує на вхід до колайдеру, щоб запустити діалог
    ///</summary>
    public class DialogTrigger : MonoBehaviour
    {
        ///<summary>
        /// Діалог для показу
        ///</summary>
        [SerializeField] private Dialog dialog;
        
        ///<summary>
        /// При перетині гравцем колайдеру розпочинається діалог
        ///</summary>
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

        ///<summary>
        /// Припинення відслідковування діалогу при визоді із колайдеру
        ///</summary>
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

        ///<summary>
        /// Метод для задання діалога
        ///</summary>
        public void SetDialog(Dialog newDialog)
        {
            dialog = newDialog;
        }
    }
}