using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _ROOT.Scripts.GlobalWorld;
using TMPro;
using UnityEngine;

namespace _ROOT.Scripts.DialogSystem
{
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
                dialog.StartDialog();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var player = other.gameObject.GetComponentInParent<Player>();
            if (player)
            {
                dialog.OnDialogEnd -= player.SubscribeForMove;
            }
        }
    }
}