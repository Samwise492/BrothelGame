using System;
using System.Collections.Generic;
using Articy.Articybrothel;
using Articy.Unity;
using Articy.Unity.Interfaces;
using UnityEngine;

namespace BrothelGame.Infrastructure.Providers
{
    public class ArticyProvider : MonoBehaviour, IArticyFlowPlayerCallbacks
    {
        public event Action<string> OnNewTextSet;
        public event Action<IList<Branch>> OnNewBranchesCreated;
        public event Action OnDialogueEnd;

        public ArticyFlowPlayer FlowPlayer => articyFlowPlayer;

        [SerializeField]
        private ArticyFlowPlayer articyFlowPlayer;

        private string speakerName;

        public void OnFlowPlayerPaused(IFlowObject aObject)
        {
            Debug.Log("OnFlowPlayerPaused");

            // If we paused on an object with a speaker name
            if (aObject is IObjectWithSpeaker objectWithSpeaker)
            {
                // If the object has a "Speaker" property, fetch the reference
                // and ensure it is really set to an "Entity" object to get its "DisplayName"
                if (objectWithSpeaker.Speaker is Entity speakerEntity)
                {
                    speakerName = speakerEntity.DisplayName;
                    Debug.Log("Speaker name: " + speakerName);
                }
            }

            // If we paused on an object that has a "Text" property fetch this text and present it
            if (aObject is IObjectWithLocalizableText objectWithText)
            {
                string finalText = $"{speakerName}: {objectWithText.Text}";
                Debug.Log("New text: " + finalText);
                OnNewTextSet?.Invoke(finalText);
            }
        }

        public void OnBranchesUpdated(IList<Branch> aBranches)
        {
            Debug.Log("OnBranchesUpdated");

            // Here we get passed a list of all branches following the current node
            // So we check if any branch leads to a DialogueFragment target
            // If so, the dialogue is not yet finished
            bool isDialogueFinished = true;
            foreach (Branch branch in aBranches)
            {
                if (branch.Target is IDialogueFragment)
                {
                    isDialogueFinished = false;
                }
            }

            if (!isDialogueFinished)
            {
                Debug.Log("Create new branches");
                OnNewBranchesCreated?.Invoke(aBranches);
            }
            else
            {
                Debug.Log("Dialogue finished");
                OnDialogueEnd?.Invoke();
            }
        }
    }
}