namespace GildedRose.Console
{
    public class MaturingSalesItem : SalesItem
    {
        public MaturingSalesItem(Item item) : base(item)
        {
        }

        public override void UpdateItemQuality()
        {
            if (Quality < MaxItemQuantity)
            {
                Quality = Quality + 1;
            }
        }

        public override void UpdateItemSellIn()
        {
            SellIn = SellIn - 1;
        }

        public override void UpdateExpiredItemQuality()
        {
            if (Quality < MaxItemQuantity)
            {
                Quality = Quality + 1;
            }
        }
    }
}
