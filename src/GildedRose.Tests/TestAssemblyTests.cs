using Xunit;
using System.Collections.Generic;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        private Inventory FullInventory;

        public TestAssemblyTests()
        {
            FullInventory = new Inventory
            {
                Items = new List<Item>
                        {
                            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                        }
            };
        }

        //system lowers Quality for every item at end of day
        [Fact]
        public void item_quality_lowered_by_one_after_each_day()
        {
            var initialQuality = FullInventory.Items[0].Quality;

            FullInventory.UpdateQuality();
            Assert.True(FullInventory.Items[0].Quality == (initialQuality - 1));
        }

        //system lowers SellIn for every item at end of day
        [Fact]
        public void item_sellin_lowered_by_one_after_each_day()
        {
            var initialSellIn = FullInventory.Items[0].SellIn;

            FullInventory.UpdateQuality();
            Assert.True(FullInventory.Items[0].SellIn == (initialSellIn - 1));
        }

        //Once the sell by date has passed, Quality degrades twice as fast
        [Fact]
        public void Quality_degrades_twice_as_fast_if_sell_by_date_passed()
        {
            var initialQuality = FullInventory.Items[0].Quality;
            FullInventory.Items[0].SellIn = 0;

            FullInventory.UpdateQuality();
            Assert.True(FullInventory.Items[0].Quality == (initialQuality - 2));
        }

        //The Quality of an item is never negative
        [Fact]
        public void item_quality_is_never_negative()
        {
            FullInventory.Items[0].Quality = 0;
            FullInventory.UpdateQuality();

            Assert.True(FullInventory.Items[0].Quality == 0);
        }

        //"Aged Brie" actually increases in Quality the older it gets
        [Fact]
        public void maturing_item_Quality_increases_as_gets_older()
        {
            var initialQuality = FullInventory.Items[1].Quality;

            FullInventory.UpdateQuality();

            Assert.True(FullInventory.Items[1].Quality > initialQuality);
        }

        //The Quality of an item is never more than 50
        [Fact]
        public void maturing_item_Quality_is_never_more_then_50()
        {
            FullInventory.Items[1].Quality = 50;
            FullInventory.UpdateQuality();

            Assert.True(FullInventory.Items[1].Quality <= 50);
        }

        //"Sulfuras", being a legendary item, never has to be sold
        [Fact]
        public void Sulfuras_never_changes_SellIn()
        {
            var initialSellIn = FullInventory.Items[3].SellIn;

            FullInventory.UpdateQuality();

            Assert.True(FullInventory.Items[3].SellIn == initialSellIn);
        }

        //"Sulfuras", being a legendary item, never decreases in Quality
        [Fact]
        public void Sulfuras_never_decreases_in_Quality()
        {
            var initialQuality = FullInventory.Items[3].Quality;

            FullInventory.UpdateQuality();

            Assert.True(FullInventory.Items[3].Quality == initialQuality);
        }

        //"Backstage passes", like aged brie, increases in Quality as it's SellIn 
        //value approaches; Quality increases by 2 when there are 10 days or less
        //and by 3 when there are 5 days or less but Quality drops to 0 after the concert
        [Fact]
        public void deadlined_items_Quality_increases_by_1_when_SellIn_greater_than_10()
        {
            var initialQuality = FullInventory.Items[4].Quality;
            FullInventory.Items[4].SellIn = 11;

            FullInventory.UpdateQuality();

            Assert.True(FullInventory.Items[4].Quality == (initialQuality + 1));
        }

        //"Backstage passes", like aged brie, increases in Quality as it's SellIn 
        //value approaches; Quality increases by 2 when there are 10 days or less
        //and by 3 when there are 5 days or less but Quality drops to 0 after the concert
        [Fact]
        public void deadlined_items_Quality_increases_by_2_when_SellIn_less_than_or_equal_to_10_but_greater_than_5()
        {
            var initialQuality = FullInventory.Items[4].Quality;
            FullInventory.Items[4].SellIn = 10;

            FullInventory.UpdateQuality();

            Assert.True(FullInventory.Items[4].Quality == (initialQuality + 2));
        }
        
        //"Backstage passes", like aged brie, increases in Quality as it's SellIn 
        //value approaches; Quality increases by 2 when there are 10 days or less
        //and by 3 when there are 5 days or less but Quality drops to 0 after the concert
        [Fact]
        public void deadlined_items_Quality_increases_by_3_when_SellIn_less_than_or_equal_to_5_but_greater_than_0()
        {
            var initialQuality = FullInventory.Items[4].Quality;
            FullInventory.Items[4].SellIn = 5;

            FullInventory.UpdateQuality();

            Assert.True(FullInventory.Items[4].Quality == (initialQuality + 3));
        }

        //"Backstage passes", like aged brie, increases in Quality as it's SellIn 
        //value approaches; Quality increases by 2 when there are 10 days or less
        //and by 3 when there are 5 days or less but Quality drops to 0 after the concert
        [Fact]
        public void deadlined_items_Quality_equals_0_when_SellIn_less_than_or_equal_to_0()
        {
            FullInventory.Items[4].SellIn = 0;
            FullInventory.UpdateQuality();

            Assert.True(FullInventory.Items[4].Quality == 0);
        }
    }
}