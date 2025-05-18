using BrothelGame.Infrastructure.Core;

namespace BrothelGame.Windows.DialogueWindow.ChoiceBranch
{
    public class ChoiceBranchView : View<ChoiceBranchHierarchy, ChoiceBranchViewModel>
    {
        public ChoiceBranchView(ChoiceBranchHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
        }

        protected override void UpdateViewModel(ChoiceBranchViewModel viewModel)
        {
            Hierarchy.Text.text = ViewModel.GetText();

            BindClick(Hierarchy.Button, ViewModel.OnSelectBranch);
        }
    }
}