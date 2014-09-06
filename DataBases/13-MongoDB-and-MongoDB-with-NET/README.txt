If you want to test the application with your own data ->
Please change the connection string at:
MongoChat.Data -> ChatSettings.Settings
or add your own connection string and use it in MongoChat.Data -> MongoDataFetcher.cs -> method: GetDatabase()