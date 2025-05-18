using System.Collections;
using System.Collections.Generic;
using BrothelGame.Infrastructure.Data;
using BrothelGame.Windows;
using UnityEngine;

namespace BrothelGame.Infrastructure.Services
{
    public interface IStaticDataService
    {
        void LoadData();
        WindowData GetWindowData(WindowId windowId);
        DialogueData GetDialogueData(DialogueId dialogueId);
        DialogueData[] DialogueData { get; }
    }
}
