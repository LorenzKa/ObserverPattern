using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Chatter
{
    public partial class ChatWindow : Window, IObserver
    {
        private readonly ChatSubject subject;
        private ObservableCollection<string> messageList = new();

        public string TopicsOfInterest => throw new NotImplementedException();

        public string Clientname { get; set; }
        public ChatWindow(ChatSubject subject)
        {
            InitializeComponent();
            this.subject = subject;
            DataContext = this;
            Clientname = subject.Name;
            nameLabel.Content = Clientname;
            subject.Attach(this);
            messageListBox.ItemsSource = messageList;
         }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            subject.NewMessage(Clientname, messageInput.Text);
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            subject.Detach(this);
        }

        public void ClientAttached(string name)
        {
            messageList.Add($"[{DateTime.Now}] {name}: has logged on");
        }

        public void ClientDetached(string name)
        {
            messageList.Add($"[{DateTime.Now}] {name}: has logged off");
        }

        public void Update(string name, string msg)
        {
            messageList.Add($"[{DateTime.Now}] {name}: {msg}");
        }
    }
}
