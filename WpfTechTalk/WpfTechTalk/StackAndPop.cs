using System.Collections.ObjectModel;
using System.Linq;

namespace WpfTechTalk
{
    public class StackAndPop : ViewModelBase
    {
        private readonly RelayCommand popA;
        private readonly RelayCommand pushA;
        private readonly ObservableCollection<string> stackA = new ObservableCollection<string>();
        private readonly ObservableCollection<string> stackB = new ObservableCollection<string>();
        private string blockName = "foo";

        public StackAndPop()
        {
            pushA = new RelayCommand(
                ()=> stackA.Add(BlockName),
                () => !string.IsNullOrWhiteSpace(BlockName));
            popA = new RelayCommand(
                () =>
                    {
                        stackB.Add(stackA.Last());
                        stackA.RemoveAt(stackA.Count - 1);
                    },
                () => stackA.Count > 0);
        }

        public string BlockName
        {
            get { return blockName; }
            set
            {
                blockName = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> StackA
        {
            get { return stackA; }
        }

        public ObservableCollection<string> StackB
        {
            get { return stackB; }
        }

        public RelayCommand PopA
        {
            get { return popA; }
        }

        public RelayCommand PushA
        {
            get { return pushA; }
        }
    }
}