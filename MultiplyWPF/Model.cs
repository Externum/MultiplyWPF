using System.Collections.ObjectModel;

namespace MultiplyWPF
{
    public class Model
    {
        private static readonly string[] stringDigits = new[] { "zero", "one", "two", "three", "four",
            "five", "six", "seven", "eight", "nine" };

        private readonly ObservableCollection<string> detailedResults = new ObservableCollection<string>();

        public Model()
        {
            DetailedResults = new ReadOnlyObservableCollection<string>(detailedResults);
        }

        public readonly ReadOnlyObservableCollection<string> DetailedResults;

        public int Multiply(int a, int b) => a * b;

        public bool CheckInt(object a, object b)
        {
            if (a is int && b is int)
                return true;
            return false;
        }

        public string ShortResult(int a)
        {
            var str = a.ToString();
            var converted = string.Empty;

            foreach (char digit in str)
            {
                converted += (stringDigits[int.Parse(digit.ToString())]+" ");
            }
            return converted;
        }

        public void DetailedResult(int a)
        {
            detailedResults.Clear();
            var str = a.ToString();

            foreach (char digit in str)
            {
                detailedResults.Add((stringDigits[int.Parse(digit.ToString())]));
            }
        }
    }
}
