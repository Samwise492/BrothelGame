using System.Collections.Generic;
using BrothelGame.Infrastructure.Data;
using BrothelGame.ScriptableObjects;
using UnityEngine;

namespace BrothelGame.Infrastructure.Services
{
    public class StaticDataService : IStaticDataService
    {
        private const string WindowStaticDataPath = "ScriptableObjects/WindowStaticData";
        private const string DialogueStaticDataPath = "ScriptableObjects/DialogueStaticData";

        public DialogueData[] DialogueData { get; private set; }

        private Dictionary<WindowId, WindowData> windowDataDictionary;
        private Dictionary<DialogueId, DialogueData> dialogueDataDictionary;

        public void LoadData()
        {
            CreateWindowData();
            CreateDialogueData();
        }

        private void CreateWindowData()
        {
            WindowStaticData staticData = Resources.Load<WindowStaticData>(WindowStaticDataPath);
            windowDataDictionary = new();

            foreach (WindowData window in staticData.Windows)
            {
                windowDataDictionary.Add(window.Id, window);
            }
        }

        private void CreateDialogueData()
        {
            DialogueStaticData staticData = Resources.Load<DialogueStaticData>(DialogueStaticDataPath);

            dialogueDataDictionary = new();
            DialogueData = new DialogueData[staticData.Dialogues.Length];

            for (int i = 0; i < staticData.Dialogues.Length; i++)
            {
                DialogueData dialogue = staticData.Dialogues[i];

                dialogueDataDictionary.Add(dialogue.Id, dialogue);
                DialogueData[i] = dialogue;
            }
        }

        public WindowData GetWindowData(WindowId windowId)
        {
            if (!windowDataDictionary.TryGetValue(windowId, out WindowData windowDataElement))
            {
                Debug.LogError($"Window data not found for window ID: {windowId}");
                return null;
            }

            return windowDataElement;
        }

        public DialogueData GetDialogueData(DialogueId dialogueId)
        {
            if (!dialogueDataDictionary.TryGetValue(dialogueId, out DialogueData dialogueDataElement))
            {
                Debug.LogError($"Dialogue data not found for dialogue ID: {dialogueId}");
                return null;
            }

            return dialogueDataElement;
        }
    }
}