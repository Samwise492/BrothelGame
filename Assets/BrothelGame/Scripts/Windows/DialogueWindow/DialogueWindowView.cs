using System.Collections;
using System.Collections.Generic;
using BrothelGame.Infrastructure.Core;
using BrothelGame.Infrastructure.Extensions;
using BrothelGame.Windows.DialogueWindow.ChoiceBranch;
using UnityEngine;

namespace BrothelGame.Windows.DialogueWindow
{
    public class DialogueWindowView : View<DialogueWindowHierarchy, DialogueWindowViewModel>
    {
        private readonly List<ChoiceBranchView> choiceBranchViews = new();

        public DialogueWindowView(DialogueWindowHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
        }

        protected override void UpdateViewModel(DialogueWindowViewModel viewModel)
        {
            ClearDialogue();

            Bind(ViewModel.IsDialogueActive, SetDialogue);
            Bind(ViewModel.ChoiceBranchViewModels, ShowBranches);
            Bind(ViewModel.DialogueText, SetText);
        }

        protected override void ReleaseViewModel()
        {
            base.ReleaseViewModel();

            ClearBranches();
        }

        private void ClearDialogue()
        {
            Hierarchy.DialogueText.text = string.Empty;
        }

        private void SetDialogue(bool isDialogueActive)
        {
            if (isDialogueActive)
            {
                ShowDialogue();
            }
            else
            {
                HideDialogue();
            }
        }

        private void ShowDialogue()
        {
            Hierarchy.DialogueCanvas.SetActive(true);
        }

        private void HideDialogue()
        {
            Hierarchy.DialogueCanvas.SetActive(false);
            Hierarchy.ChoiceCanvas.SetActive(false);
            ClearDialogue();
        }

        private void SetText(string text)
        {
            Hierarchy.DialogueText.text = text;
        }

        private void ShowBranches(List<ChoiceBranchViewModel> choiceBranchViewModels)
        {
            if (choiceBranchViewModels.Count == 0)
            {
                return;
            }

            ClearBranches();

            Hierarchy.ChoiceCanvas.SetActive(true);

            foreach (ChoiceBranchViewModel choiceBranchViewModel in choiceBranchViewModels)
            {
                CreateBranch(choiceBranchViewModel);
            }
        }

        private void CreateBranch(ChoiceBranchViewModel choiceBranchViewModel)
        {
            ChoiceBranchView view = CreateView<ChoiceBranchView, ChoiceBranchHierarchy>(Hierarchy.ChoiceBranchPrefab, Hierarchy.ChoiceBranchContainer);
            view.Initialize(choiceBranchViewModel);

            choiceBranchViews.Add(view);
        }

        private void ClearBranches()
        {
            foreach (ChoiceBranchView choiceBranchView in choiceBranchViews)
            {
                choiceBranchView.ClearViewModel();
                Object.Destroy(choiceBranchView.Hierarchy.gameObject);
            }

            choiceBranchViews.Clear();
        }
    }
}