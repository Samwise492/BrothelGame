using System.Collections.Generic;
using Articy.Unity;
using BrothelGame.Infrastructure.Core;
using BrothelGame.Windows.DialogueWindow.ChoiceBranch;
using R3;
using Zenject;

namespace BrothelGame.Windows.DialogueWindow
{
    public class DialogueWindowViewModel : ViewModel<DialogueWindow>
    {
        public ReactiveProperty<bool> IsDialogueActive = new();
        public ReactiveProperty<string> DialogueText = new();
        public ReactiveProperty<List<ChoiceBranchViewModel>> ChoiceBranchViewModels = new();

        private readonly IInstantiator _instantiator;

        public DialogueWindowViewModel(DialogueWindow model, IInstantiator instantiator) : base(model)
        {
            _instantiator = instantiator;

            Initialize();
            Subscribe();
        }

        public override void Dispose()
        {
            base.Dispose();

            Unsubscribe();
        }

        private void Initialize()
        {
            ChoiceBranchViewModels.Value = new();
        }

        private void Subscribe()
        {
            Model.OnDialogueGoing += CheckDialogueState;
            Model.OnNewBranchesCreated += CreateBranches;
            Model.OnNewTextSet += SetDialogueText;
        }

        private void Unsubscribe()
        {
            Model.OnDialogueGoing -= CheckDialogueState;
            Model.OnNewBranchesCreated -= CreateBranches;
            Model.OnNewTextSet -= SetDialogueText;
        }

        private void CheckDialogueState(bool isDialogueActive)
        {
            IsDialogueActive.Value = isDialogueActive;
        }

        private void CreateBranches(IList<Branch> branches)
        {
            List<ChoiceBranchViewModel> choiceBranchViewModels = new();

            foreach (Branch branch in branches)
            {
                choiceBranchViewModels.Add(CreateBranch(branch));
            }

            ChoiceBranchViewModels.Value = choiceBranchViewModels;
        }

        private ChoiceBranchViewModel CreateBranch(Branch branch)
        {
            ChoiceBranch.ChoiceBranch choiceBranch = new(Model.FlowPlayer, branch);

            ChoiceBranchViewModel choiceBranchViewModel = _instantiator.Instantiate<ChoiceBranchViewModel>(new object[] { choiceBranch });

            return choiceBranchViewModel;
        }

        private void SetDialogueText(string text)
        {
            DialogueText.Value = text;
        }
    }
}