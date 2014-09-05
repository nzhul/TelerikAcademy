namespace MongoChat.Client.Console
{
    using System;
    using MongoChat.Data;

    class Program
    {
        static void Main()
        {
            MongoDataFetcher dataFetcher = new MongoDataFetcher();
            var allMessages = dataFetcher.ReadAllMessages();

            foreach (var item in allMessages)
            {
                Console.WriteLine(item.Text);
            }


            var asddd = 1;
        }
    }
}
