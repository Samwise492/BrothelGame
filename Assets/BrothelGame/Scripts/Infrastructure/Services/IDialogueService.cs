using System.Collections;
using System.Collections.Generic;
using BrothelGame.Infrastructure.Data;
using UnityEngine;

namespace BrothelGame.Infrastructure.Services
{
    public interface IDialogueService
    {
        void StartDialogue(DialogueId dialogueId);
        void StartDialogueSequence(int indexFrom, int indexTo);
    }
}