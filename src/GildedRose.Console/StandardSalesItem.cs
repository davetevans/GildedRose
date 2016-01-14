namespace GildedRose.Console
{
    public class StandardSalesItem : SalesItem
    {
        public StandardSalesItem(Item item) : base(item)
        {
        }

        public override void UpdateItemQuality()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }
        }

        public override void UpdateItemSellIn()
        {
            SellIn = SellIn - 1;
        }

        public override void UpdateExpiredItemQuality()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }
        }
    }
}
