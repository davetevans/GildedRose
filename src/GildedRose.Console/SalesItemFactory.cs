namespace GildedRose.Console
{
    public static class SalesItemFactory
    {
        public static SalesItem Create(Item item)
        {
            if (IsMaturing(item))
            {
                return new StandardItem(item);
            }

            if (IsMaturing(item))
            {
                return new MaturingItem(item);
            }

            if (IsLegendary(item))
            {
                return new LegendaryItem(item);
            }

            if (IsDeadlined(item))
            {
                return new DeadlinedItem(item);
            }

            if (IsConjured(item))
            {
                return new ConjuredItem(item);
            }

            return new StandardItem(item);
        }

        private static bool IsMaturing(Item item)
        {
            // includes all items that increase in quality as they increase in age
            return item.Name == "Aged Brie";
        }

        private static bool IsLegendary(Item item)
        {
            // includes all items that never have to be sold and never decrease in quality
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private static bool IsDeadlined(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static bool IsConjured(Item item)
        {
            return item.Name == "Conjured Mana Cake";
        }
    }

    public class StandardItem : SalesItem
    {
        public StandardItem(Item item) : base(item)
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

    public class MaturingItem : SalesItem
    {
        public MaturingItem(Item item) : base(item)
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

    public class LegendaryItem : SalesItem
    {
        public LegendaryItem(Item item) : base(item)
        {
        }

        public override void UpdateItemQuality()
        {
        }

        public override void UpdateExpiredItemQuality()
        {
        }
    }

    public class DeadlinedItem : SalesItem
    {
        public DeadlinedItem(Item item) : base(item)
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

    public class ConjuredItem : SalesItem
    {
        public ConjuredItem(Item item) : base(item)
        {
        }

        public override void UpdateItemQuality()
        {
            if (Quality > 0)
            {
                Quality = Quality - 2;
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
                Quality = Quality - 2;
            }
        }
    }
}
