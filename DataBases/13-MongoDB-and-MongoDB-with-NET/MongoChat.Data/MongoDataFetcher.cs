namespace MongoChat.Data
{
    using System;
    using System.Collections.Generic;
    using MongoChat.Model;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    public class MongoDataFetcher
    {

        private Lazy<MongoDatabase> database = new Lazy<MongoDatabase>(GetDatabase);

        public MongoCursor<Message> ReadAllMessages()
        {
            var collection = this.database.Value.GetCollection<Message>("Messages");
            
            var messages = collection.FindAll();

            return messages;
        }

        public MongoCursor<Message> ReadAllMessages(string byUser)
        {
            throw new NotImplementedException();
        }

        private static MongoDatabase GetDatabase()
        {
            var mongoClient = new MongoClient(ChatSettings.Default.DataBaseHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(ChatSettings.Default.DataBaseName);
        }
    }
}
