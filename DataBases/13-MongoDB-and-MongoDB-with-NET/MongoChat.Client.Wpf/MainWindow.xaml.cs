using MongoChat.Data;
using MongoChat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace MongoChat.Client.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillMessageData();
        }

        private void FillMessageData()
        {
            MongoDataFetcher dataFetcher = new MongoDataFetcher();
            var allMessages = dataFetcher.ReadAllMessages();
            lvMessages.ItemsSource = allMessages;
        }

        private void SendMessage()
        {
            MongoDataFetcher dataFetcher = new MongoDataFetcher();

            Message newMessage = new Message();
            newMessage.Author = "Atanas";
            newMessage.DateAdded = DateTime.Now;
            newMessage.Text = "Хайде пичове и аз съм в играта вече!";
            dataFetcher.SendMessage(newMessage);
        }

        private void userInput_KeyDown_1(object sender, KeyEventArgs e)
        {
            var newWindow = new Window();
            if (e.Key == Key.Enter) 
            {
                SendMessage();
            }
        }
    }
}
