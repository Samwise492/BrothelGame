using BrothelGame.Infrastructure.Core;

namespace BrothelGame.Windows.DialogueWindow.ChoiceBranch
{
    public class ChoiceBranchViewModel : ViewModel<ChoiceBranch>
    {
        public ChoiceBranchViewModel(ChoiceBranch model) : base(model)
        {
        }

        public void OnSelectBranch()
        {
            Model.OnSelectBranch();
        }

        internal string GetText()
        {
            return Model.Text;
        }
    }
}