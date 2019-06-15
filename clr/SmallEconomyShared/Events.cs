namespace SmallEconomy.Shared
{
    /// <summary>
    /// Event definitions.
    /// </summary>
    public static class Events
    {
        public static string GetMoneyEventServer = "SmallEcon:Server:GetMoney";
        public static string GetMoneyEventClient = "SmallEcon:Client:GetMoney";

        public static string UseItemEventServer = "SmallEcon:Server:UseItem";
        public static string UseItemEventClient = "SmallEcon:Client:UseItem";

        public static string ListItemsEventServer = "SmallEcon:Server:ListItems";
        public static string ListItemsEventClient = "SmallEcon:Client:ListItems";

        public static string ViewStoreEventServer = "SmallEcon:Server:ViewStore";
        public static string ViewStoreEventClient = "SmallEcon:Client:ViewStore";

        public static string BuyItemEventServer = "SmallEcon:Server:BuyItem";
        public static string BuyItemEventClient = "SmallEcon:Client:BuyItem";

        public static string StashItemEventServer = "SmallEcon:Server:StashItem";
        public static string StashItemEventClient = "SmallEcon:Client:StashItem";
    }
}
