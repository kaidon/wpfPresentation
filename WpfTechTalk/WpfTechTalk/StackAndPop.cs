using System.Collections.ObjectModel;
using System.Linq;

namespace WpfTechTalk
{
    public class StackAndPop : ViewModelBase
    {
        private readonly RelayCommand<string> popA;
        private readonly RelayCommand<string> pushA;
        private readonly ObservableCollection<string> stackA = new ObservableCollection<string>();
        private readonly ObservableCollection<string> stackB = new ObservableCollection<string>();
        private string blockName = "foo";

        public StackAndPop()
        {
            pushA = new RelayCommand<string>(
                s => stackA.Add(s),
                s => !string.IsNullOrWhiteSpace(s));
            popA = new RelayCommand<string>(
                s =>
                    {
                        stackB.Add(stackA.Last());
                        stackA.RemoveAt(stackA.Count - 1);
                    },
                s => stackA.Count > 0);
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

        public RelayCommand<string> PopA
        {
            get { return popA; }
        }

        public RelayCommand<string> PushA
        {
            get { return pushA; }
        }
    }
}