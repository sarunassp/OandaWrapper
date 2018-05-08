namespace OandaTest
{
    public class Constants
    {
        public const string ApiToken = "6ddff649ad8463de5eceb801421488fd-1556ea5488f8abccbf755745dc18cf84";
        public const string AccountId = "101-004-8362538-001";
    }
    
    public class OrderType
    {
        public const string Market = "MARKET";
        public const string Limit = "LIMIT";
    }

    public class InstrumentName
    {
        public const string EurUsd = "EUR_USD";
        public const string EurCad = "EUR_CAD";
    }

    public class TimeInForce
    {
        public const string GoodUntilCancelled = "GTC";
        public const string GoodUntilDate = "GTD";
        public const string GoodForDay = "GFD";
        public const string FilledOrKilled = "FOK";
        public const string ImmediatedlyPartiallyFilledOrCancelled = "IOC";
    }

    public class Granularity
    {
        public const string FiveSecond = "S5";
        public const string TenSecond = "S10";
        public const string FifteenSecond = "S15";
        public const string ThirtySecond = "S30";    
    }
}