using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chatter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IObserver
    {
        private ChatSubject clientSubject = new ChatSubject();
        private ObservableCollection<string> messageList = new();
        private ObservableCollection<string> loginList = new();
        public string Clientname { get; set; }
        public string TopicsOfInterest => throw new NotImplementedException();
        public MainWindow()
        {
            InitializeComponent();
            Clientname = "SERVER";
            clientSubject.Attach(this);
            messageBox.ItemsSource = messageList;
            loginBox.ItemsSource = loginList;
            DataContext = this;
        }


        public void ClientAttached(string name)
        {
            if (name != Clientname)
            {
                loginList.Add($"[{DateTime.Now}] {name}: has logged on");

                numberLabel.Content = "Nr. Clients: " + (clientSubject.NrObservers - 1);
            }
        }

        public void ClientDetached(string name)
        {

            loginList.Add($"[{DateTime.Now}] {name}: has logged off");
            numberLabel.Content = "Nr. Clients: " + (clientSubject.NrObservers - 1);
        }

        public void Update(string name, string msg)
        {
            messageList.Add($"[{DateTime.Now}] {name}: {msg}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clientSubject.Name = textBoxName.Text;
            var window = new ChatWindow(clientSubject);
            window.Show();
        }

    }
}
