using MongoChat.Data;
using MongoChat.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MongoChat.Client.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MongoDataFetcher dataFetcher;
        public MainWindow()
        {
            InitializeComponent();
            this.dataFetcher = new MongoDataFetcher();
            FillMessageData();
        }

        private void FillMessageData()
        {
            var allMessages = this.dataFetcher.ReadAllMessages();

            foreach (var message in allMessages)
            {
                Message currentMessage = new Message();
                currentMessage.Author = message.Author;
                currentMessage.Text = message.Text;
                currentMessage.DateAdded = message.DateAdded;
                lvMessages.Items.Add(currentMessage);
            }
        }


        private void UserInputKeyDownEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                var userInput = sender as TextBox;

                Message newMessage = new Message();
                newMessage.Author = "Guest";
                newMessage.DateAdded = DateTime.Now;
                newMessage.Text = userInput.Text;
                userInput.Text = "";

                UpdateMessagesUI(newMessage);
                this.dataFetcher.SendMessage(newMessage);
            }
        }

        private void UpdateMessagesUI(Message newMessage)
        {
            lvMessages.Items.Add(newMessage);
        }

        private void SubmitMsg_Click(object sender, RoutedEventArgs e)
        {
            Message newMessage = new Message();
            newMessage.Author = "Guest";
            newMessage.DateAdded = DateTime.Now;
            newMessage.Text = userInput.Text;
            userInput.Text = "";

            UpdateMessagesUI(newMessage);
            this.dataFetcher.SendMessage(newMessage);
        }


    }
}
