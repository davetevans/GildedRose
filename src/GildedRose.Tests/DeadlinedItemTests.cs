using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class DeadlinedItemTests
    {
        private Item _item;
        private SalesItem _salesItem;

        public DeadlinedItemTests()
        {
            _item = TestItems.DeadlinedItem;
            _salesItem = SalesItemFactory.Create(_item);
        }
        
        //system lowers SellIn for every item at end of day
        [Fact]
        public void item_sellin_lowered_by_one_after_each_day()
        {
            _salesItem.UpdateQuality();

            Assert.True(_item.SellIn == 14);
        }
        
        //The Quality of an item is never negative
        [Fact]
        public void item_quality_is_never_negative()
        {
            _item.Quality = 0;

            _salesItem.UpdateQuality();

            Assert.True(_item.Quality >= 0);
        }

        //The Quality of an item is never more than 50
        [Fact]
        public void item_quality_is_never_more_then_50()
        {
            _item.Quality = 50;

            _salesItem.UpdateQuality();

            Assert.True(_item.Quality <= 50);
        }

        //"Backstage passes", like aged brie, increases in Quality as it's SellIn 
        //value approaches; Quality increases by 2 when there are 10 days or less
        //and by 3 when there are 5 days or less but Quality drops to 0 after the concert
        [Fact]
        public void deadlined_items_quality_increases_by_1_when_SellIn_greater_than_10()
        {
            _item.SellIn = 11;

            _salesItem.UpdateQuality();

            Assert.True(_item.Quality == 21);
        }

        //"Backstage passes", like aged brie, increases in Quality as it's SellIn 
        //value approaches; Quality increases by 2 when there are 10 days or less
        //and by 3 when there are 5 days or less but Quality drops to 0 after the concert
        [Fact]
        public void deadlined_items_quality_increases_by_2_when_SellIn_less_than_or_equal_to_10_but_greater_than_5()
        {
            _item.SellIn = 10;

            _salesItem.UpdateQuality();

            Assert.True(_item.Quality == 22);
        }

        //"Backstage passes", like aged brie, increases in Quality as it's SellIn 
        //value approaches; Quality increases by 2 when there are 10 days or less
        //and by 3 when there are 5 days or less but Quality drops to 0 after the concert
        [Fact]
        public void deadlined_items_Quality_increases_by_3_when_SellIn_less_than_or_equal_to_5_but_greater_than_0()
        {
            _item.SellIn = 5;

            _salesItem.UpdateQuality();

            Assert.True(_item.Quality == 23);
        }

        //"Backstage passes", like aged brie, increases in Quality as it's SellIn 
        //value approaches; Quality increases by 2 when there are 10 days or less
        //and by 3 when there are 5 days or less but Quality drops to 0 after the concert
        [Fact]
        public void deadlined_items_Quality_equals_0_when_SellIn_less_than_or_equal_to_0()
        {
            _item.SellIn = 0;

            _salesItem.UpdateQuality();

            Assert.True(_item.Quality == 0);
        }
    }
}