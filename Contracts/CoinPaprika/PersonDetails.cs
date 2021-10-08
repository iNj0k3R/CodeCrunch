namespace CodeCrunch.Contracts.CoinPaprika
{

    public class PersonDetails
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int teams_count { get; set; }
        public Links links { get; set; }
        public Position[] positions { get; set; }
    }

    public class Links
    {
        public Github[] github { get; set; }
        public Linkedin[] linkedin { get; set; }
        public Medium[] medium { get; set; }
        public Twitter[] twitter { get; set; }
    }

    public class Github
    {
        public string url { get; set; }
        public int followers { get; set; }
    }

    public class Linkedin
    {
        public string url { get; set; }
    }

    public class Medium
    {
        public string url { get; set; }
        public int followers { get; set; }
    }

    public class Twitter
    {
        public string url { get; set; }
        public int followers { get; set; }
    }

    public class Position
    {
        public string coin_id { get; set; }
        public string coin_name { get; set; }
        public string coin_symbol { get; set; }
        public string position { get; set; }
    }

}
