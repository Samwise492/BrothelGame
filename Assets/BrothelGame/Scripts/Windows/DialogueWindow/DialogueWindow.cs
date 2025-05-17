using System;
using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using Articy.Unity.Interfaces;
using R3;
using UnityEngine;

namespace BrothelGame.Windows.DialogueWindow
{
    // TODO: Разделить ответственность, не должно окно знать про артиси
    public class DialogueWindow : IArticyFlowPlayerCallbacks
    {
        public event Action<bool> OnDialogueGoing;
        public string DialogueText { get; private set; }

        public void StartDialogue(ArticyFlowPlayer flowPlayer, IArticyObject aObject)
        {
            flowPlayer.StartOn = aObject;

            OnDialogueGoing?.Invoke(true);
        }

        public void OnFlowPlayerPaused(IFlowObject aObject)
        {
            if (aObject is IObjectWithText objectWithText)
            {
                DialogueText = objectWithText.Text;
            }
        }

        public void OnBranchesUpdated(IList<Branch> aBranches)
        {
        }
    }
}