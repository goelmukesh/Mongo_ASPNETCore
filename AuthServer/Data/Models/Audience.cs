namespace AuthServer.Data.Models
{
    public class Audience
    {
        //these value are defined by the app setting config file which will used by the api
        public string Secret { get; set; }
        public string Iss { get; set; }
        public string Aud { get; set; }
    }
}
