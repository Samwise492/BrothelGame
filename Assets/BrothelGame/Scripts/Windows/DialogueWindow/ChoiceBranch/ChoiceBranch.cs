using System;
using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using Articy.Unity.Interfaces;
using UnityEngine;

namespace BrothelGame.Windows.DialogueWindow.ChoiceBranch
{
    public class ChoiceBranch
    {
        public string Text { get; private set; }

        private readonly ArticyFlowPlayer flowPlayer;
        private readonly Branch branch;

        public ChoiceBranch(ArticyFlowPlayer flowPlayer, Branch branch)
        {
            this.flowPlayer = flowPlayer;
            this.branch = branch;

            Text = string.Empty;
            TryShowMenuText();
        }

        public void OnSelectBranch()
        {
            flowPlayer.Play(branch);
        }

        private void TryShowMenuText()
        {
            if (branch.Target is IObjectWithMenuText objectWithMenuText)
            {
                Text = objectWithMenuText.MenuText;
            }

            if (NoMenuTextFound())
            {
                Debug.Log($"No menu text found for branch, setting regular text");
                Text = "...";
            }
        }

        private bool NoMenuTextFound()
        {
            return string.IsNullOrEmpty(Text);
        }
    }
}