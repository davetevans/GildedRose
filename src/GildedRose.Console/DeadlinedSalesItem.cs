namespace GildedRose.Console
{
    public class DeadlinedSalesItem : SalesItem
    {
        public DeadlinedSalesItem(Item item) : base(item)
        {
        }

        public override void UpdateItemQuality()
        {
            if (Quality < MaxItemQuantity)
            {
                Quality = Quality + 1;

                if (SellIn < 11)
                {
                    Quality = Quality + 1;
                }

                if (SellIn < 6)
                {
                    Quality = Quality + 1;
                }
            }
        }

        public override void UpdateItemSellIn()
        {
            SellIn = SellIn - 1;
        }

        public override void UpdateExpiredItemQuality()
        {
            Quality = 0;
        }
    }
}
