namespace MovieApp.Settings {
    public class MongoDBSettings {
        public string Host {get; set;}
        public string Port {get; set;}
        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionString {
            get => $"mongodb://{User}:{Password}@{Host}:{Port}";
        }
    }
}