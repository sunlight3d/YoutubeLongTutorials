namespace MovieApp.Settings {
    public class MongoDBSettings {
        public string Host {get; set;}
        public string Port {get; set;}
        public string ConnectionString {
            get => $"mongodb://{Host}:{Port}";
        }
    }
}