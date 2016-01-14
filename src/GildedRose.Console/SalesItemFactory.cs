namespace GildedRose.Console
{
    public static class SalesItemFactory
    {
        public static SalesItem Create(Item item)
        {
            if (IsMaturing(item))
            {
                return new MaturingSalesItem(item);
            }

            if (IsLegendary(item))
            {
                return new LegendarySalesItem(item);
            }

            if (IsDeadlined(item))
            {
                return new DeadlinedSalesItem(item);
            }

            if (IsConjured(item))
            {
                return new ConjuredSalesItem(item);
            }

            return new StandardSalesItem(item);
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
}
