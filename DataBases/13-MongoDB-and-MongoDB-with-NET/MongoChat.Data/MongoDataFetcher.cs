namespace MongoChat.Data
{
    using System;
    using System.Collections.Generic;
    using MongoChat.Model;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    public class MongoDataFetcher
    {

        private readonly Lazy<MongoDatabase> database = new Lazy<MongoDatabase>(GetDatabase);

        public MongoCursor<Message> ReadAllMessages()
        {
            var collection = this.database.Value.GetCollection<Message>("Messages");
            
            var messages = collection.FindAll();

            return messages;
        }

        public MongoCursor<Message> ReadAllMessages(string byUser)
        {
            var collection = this.database.Value.GetCollection<Message>("Messages");

            var query = Query.EQ("Author", byUser);
            var messages = collection.Find(query);

            return messages;
        }

        public void SendMessage(Message message)
        {
            var collection = this.database.Value.GetCollection<Message>("Messages");
            try
            {
                collection.Insert(message);
            }
            catch (Exception)
            {
                throw new MongoConnectionException("Problem Sending the message!");
            }
        }

        private static MongoDatabase GetDatabase()
        {
            //var mongoClient = new MongoClient(ChatSettings.Default.DatabaseLocalHost);
            var mongoClient = new MongoClient(ChatSettings.Default.DataBaseHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(ChatSettings.Default.DataBaseName);
        }
    }
}
