using GildedRose.Console;

namespace GildedRose.Tests
{
    public static class TestItems
    {
        public static Item StandardItem
        {
            get
            {
                return new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            }
        }
        
        public static Item MaturingItem
        {
            get
            {
                return new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
            }
        }

        public static Item LegendaryItem
        {
            get
            {
                return new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
            }
        }

        public static Item DeadlinedItem
        {
            get
            {
                return new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
            }
        }

        public static Item ConjuredItem
        {
            get
            {
                return new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 };
            }
        }

        public static Item HmmmmItem
        {
            get
            {
                return new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 };
            }
        }
    }
}