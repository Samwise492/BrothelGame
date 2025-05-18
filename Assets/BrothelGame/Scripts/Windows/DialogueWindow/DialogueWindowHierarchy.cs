using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Articy.Unity;
using Articy.Unity.Interfaces;
using UnityEngine.UI;
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