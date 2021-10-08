namespace CodeCrunch.Contracts.CoinPaprika
{

    //public class CoinDetails
    //{
    //    public string id { get; set; }
    //    public string name { get; set; }
    //    public string symbol { get; set; }
    //    public int rank { get; set; }
    //    public bool is_new { get; set; }
    //    public bool is_active { get; set; }
    //    public string type { get; set; }
    //}

    public class CoinDetails
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public int rank { get; set; }
        public bool is_new { get; set; }
        public bool is_active { get; set; }
        public string type { get; set; }
        public Tag[] tags { get; set; }
        public Team[] team { get; set; }
        public string description { get; set; }
        public string message { get; set; }
        public bool open_source { get; set; }
        public DateTime started_at { get; set; }
        public string development_status { get; set; }
        public bool hardware_wallet { get; set; }
        public string proof_type { get; set; }
        public string org_structure { get; set; }
        public string hash_algorithm { get; set; }
        public Links links { get; set; }
        public Links_Extended[] links_extended { get; set; }
        public Whitepaper whitepaper { get; set; }
        public DateTime first_data_at { get; set; }
        public DateTime last_data_at { get; set; }
    }

    public class Links
    {
        public string[] explorer { get; set; }
        public string[] facebook { get; set; }
        public string[] reddit { get; set; }
        public string[] source_code { get; set; }
        public string[] website { get; set; }
        public string[] youtube { get; set; }
    }

    public class Whitepaper
    {
        public string link { get; set; }
        public string thumbnail { get; set; }
    }

    public class Tag
    {
        public string id { get; set; }
        public string name { get; set; }
        public int coin_counter { get; set; }
        public int ico_counter { get; set; }
    }

    public class Team
    {
        public string id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
    }

    public class Links_Extended
    {
        public string url { get; set; }
        public string type { get; set; }
        public Stats stats { get; set; }
    }

    public class Stats
    {
        public int subscribers { get; set; }
        public int contributors { get; set; }
        public int stars { get; set; }
        public int followers { get; set; }
    }


}
