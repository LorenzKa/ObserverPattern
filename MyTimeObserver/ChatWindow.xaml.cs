using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Chatter
{
    public partial class ChatWindow : Window, INotifyPropertyChanged, IObserver
    {
        private readonly ChatSubject subject;
        private string name = "Lorenz";
        private List<string> messageList = new();
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public string Clientname => "Lorenz";

        public string TopicsOfInterest => throw new NotImplementedException();

        public ChatWindow(ChatSubject subject)
        {
            InitializeComponent();
            this.subject = subject;
            DataContext = this;
            subject.Attach(this);
            messageListBox.ItemsSource = messageList;
         }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            subject.NewMessage(name, messageInput.Text);
        }

        

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            subject.Detach(this);
        }

        public void ClientAttached(string name)
        {
            subject.Attach(this);
        }

        public void ClientDetached(string name)
        {

        }

        public void Update(string name, string msg)
        {
            messageList.Add($"{name}: {msg}");
            messageListBox.ItemsSource = messageList;
        }
    }
}
