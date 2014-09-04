namespace _TestingMongo
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        const string DatabaseHost = "mongodb://127.0.0.1";
        const string DatabaseName = "Logger";

        class Log
        {
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            public string name { get; set; }
        }



        static MongoDatabase GetDatabase(string name, string fromHost)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }
        static void Main()
        {
            var db = GetDatabase(DatabaseName, DatabaseHost);
            var collection = db.GetCollection<Log>("Logs");

            collection.FindAll().Select(log => string.Format("[{0}]-->{1}", log.Id, log.name))
                .Print();





            //vObjs.Insert(new Log() { 
            //    Id = ObjectId.GenerateNewId().ToString(),
            //    LogDate = DateTime.Now,
            //    Text = "Some text from C#"
            //});

            //vObjs.Insert(new {
            //    Id = ObjectId.GenerateNewId().ToString(),
            //    Name = "Doncho1"
            //});


        }
    }
}
