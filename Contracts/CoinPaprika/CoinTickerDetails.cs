namespace CodeCrunch.Contracts.CoinPaprika
{

    public class CoinTickerDetails
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public int rank { get; set; }
        public long circulating_supply { get; set; }
        public long total_supply { get; set; }
        public long max_supply { get; set; }
        public float beta_value { get; set; }
        public DateTime first_data_at { get; set; }
        public DateTime last_updated { get; set; }
        public Quotes quotes { get; set; }
    }

    public class Quotes
    {
        public USD USD { get; set; }
    }

    public class USD
    {
        public float price { get; set; }
        public float volume_24h { get; set; }
        public float volume_24h_change_24h { get; set; }
        public long market_cap { get; set; }
        public float market_cap_change_24h { get; set; }
        public float percent_change_15m { get; set; }
        public float percent_change_30m { get; set; }
        public float percent_change_1h { get; set; }
        public float percent_change_6h { get; set; }
        public float percent_change_12h { get; set; }
        public float percent_change_24h { get; set; }
        public float percent_change_7d { get; set; }
        public float percent_change_30d { get; set; }
        public float percent_change_1y { get; set; }
        public float? ath_price { get; set; }
        public DateTime? ath_date { get; set; }
        public float? percent_from_price_ath { get; set; }
    }

}
