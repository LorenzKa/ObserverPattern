using System.ComponentModel;
using System.Windows;

namespace MyTimeObserver
{
    public partial class ClockOberserWindow : Window, INotifyPropertyChanged, IObserver
    {
        private readonly ClockSubject subject;
        private string time = "";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string? Time
        {
            get => time;
            set
            {
                time = value ?? "";
                OnPropertyChanged(nameof(Time));
            }
        }
        public ClockOberserWindow(ClockSubject subject)
        {
            InitializeComponent();
            this.subject = subject;
            DataContext = this;
            subject.Attach(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
