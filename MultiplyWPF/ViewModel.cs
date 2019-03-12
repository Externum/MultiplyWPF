using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MultiplyWPF
{
    class ViewModel : INotifyPropertyChanged
    {
        private string shortAnswer;
        private int detailedFirstNumber;
        private int detailedSecondNumber;

        readonly Model model = new Model();

        public ReadOnlyObservableCollection<string> DetailedResults => model.DetailedResults;

        public string ShortAnswer
        {
            get { return shortAnswer; }
            private set
            {
                shortAnswer = value;
                OnPropertyChanged("ShortAnswer");
            }
        }

        public int DetailedAnswer
        {
            get
            {
                var res = model.Multiply(DetailedFirstNumber, DetailedSecondNumber);
                model.DetailedResult(res);
                return res;
            }
        }
        public int DetailedFirstNumber
        {
            get { return detailedFirstNumber; }
            set
            {
                detailedFirstNumber = value;
                OnPropertyChanged("DetailedAnswer");
            }
        }

        public int DetailedSecondNumber
        {
            get { return detailedSecondNumber; }
            set
            {
                detailedSecondNumber = value;
                OnPropertyChanged("DetailedAnswer");
            }
        }

        public int ShortFirstNumber { get; set; }
        public int ShortSecondNumber { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand ClickMultiply
        {
            get
            {
                return new MultiplyCommand(() =>
                {
                    ShortAnswer = model.ShortResult(model.Multiply(ShortFirstNumber, ShortSecondNumber));
                }, 
                () => model.CheckInt(ShortFirstNumber, ShortSecondNumber));
            }
        }
    }
}
