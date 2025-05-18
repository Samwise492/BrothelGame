using UnityEngine;
using TMPro;
using BrothelGame.Windows.DialogueWindow.ChoiceBranch;

namespace BrothelGame.Windows.DialogueWindow
{
    public class DialogueWindowHierarchy : MonoBehaviour
    {
        public CanvasGroup DialogueCanvas;
        public TMP_Text DialogueText;

        [Space]
        public CanvasGroup ChoiceCanvas;
        public Transform ChoiceBranchContainer;
        public ChoiceBranchHierarchy ChoiceBranchPrefab;
    }
}