using System.Collections;
using System.Collections.Generic;
using BrothelGame.Infrastructure.Core;
using R3;
using UnityEngine;

namespace BrothelGame.Windows.DialogueWindow
{
    public class DialogueWindowViewModel : ViewModel<DialogueWindow>
    {
        public ReactiveProperty<bool> IsDialogueActive = new();

        public string DialogueText => Model.DialogueText;

        public DialogueWindowViewModel(DialogueWindow model) : base(model)
        {
            Model.OnDialogueGoing += CheckDialogueText;
        }

        public override void Dispose()
        {
            base.Dispose();

            Model.OnDialogueGoing -= CheckDialogueText;
        }

        private void CheckDialogueText(bool isDialogueActive)
        {
            IsDialogueActive.Value = isDialogueActive;
        }
    }
}