using System;
using System.Collections.Generic;
using Articy.Unity;
using Articy.Unity.Interfaces;
using BrothelGame.Infrastructure.Providers;
using UnityEngine;

namespace BrothelGame.Windows.DialogueWindow
{
    public class DialogueWindow
    {
        public event Action<bool> OnDialogueGoing;
        public event Action<string> OnNewTextSet;
        public event Action<IList<Branch>> OnNewBranchesCreated;

        public ArticyFlowPlayer FlowPlayer => flowPlayer;

        private readonly ArticyFlowPlayer flowPlayer;

        public DialogueWindow(ArticyProvider articyProvider)
        {
            flowPlayer = articyProvider.FlowPlayer;

            ResetSubscriptions(articyProvider);
        }

        public void StartDialogue(IArticyObject aObject)
        {
            flowPlayer.StartOn = aObject;
            flowPlayer.Play();
            Debug.Log("Starting dialogue " + aObject.TechnicalName);

            OnDialogueGoing?.Invoke(true);
        }

        private void ResetSubscriptions(ArticyProvider articyProvider)
        {
            articyProvider.OnNewTextSet -= SetText;
            articyProvider.OnNewBranchesCreated -= SetBranches;
            articyProvider.OnDialogueEnd -= EndDialogue;

            articyProvider.OnNewTextSet += SetText;
            articyProvider.OnNewBranchesCreated += SetBranches;
            articyProvider.OnDialogueEnd += EndDialogue;
        }

        private void SetText(string text)
        {
            OnNewTextSet?.Invoke(text);
        }

        private void SetBranches(IList<Branch> branches)
        {
            OnNewBranchesCreated?.Invoke(branches);
        }

        private void EndDialogue()
        {
            OnDialogueGoing?.Invoke(false);
        }
    }
}