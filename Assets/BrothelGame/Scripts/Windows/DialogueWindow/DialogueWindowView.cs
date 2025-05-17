using System.Collections;
using System.Collections.Generic;
using BrothelGame.Infrastructure.Core;
using BrothelGame.Infrastructure.Extensions;
using UnityEngine;

namespace BrothelGame.Windows.DialogueWindow
{
    public class DialogueWindowView : View<DialogueWindowHierarchy, DialogueWindowViewModel>
    {
        public DialogueWindowView(DialogueWindowHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
        }

        protected override void UpdateViewModel(DialogueWindowViewModel viewModel)
        {
            ClearDialogue();

            Bind(ViewModel.IsDialogueActive, SetDialogue);
        }

        private void SetDialogue(bool isDialogueActive)
        {
            if (isDialogueActive)
            {
                ShowDialogue(ViewModel.DialogueText);
            }
            else
            {
                HideDialogue();
            }
        }

        public void ShowDialogue(string aDialogueLine)
        {
            Hierarchy.DialogueCanvas.SetActive(true);
            Hierarchy.DialogueText.text = aDialogueLine;
        }

        public void HideDialogue()
        {
            Hierarchy.DialogueCanvas.SetActive(false);
            ClearDialogue();
        }

        private void ClearDialogue()
        {
            Hierarchy.DialogueText.text = string.Empty;
        }
    }
}