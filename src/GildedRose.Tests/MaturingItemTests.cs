using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class MaturingItemTests
    {
        private Item _item;
        private SalesItem _salesItem;

        public MaturingItemTests()
        {
            _item = TestItems.MaturingItem;
            _salesItem = SalesItemFactory.Create(_item);
        }

        //system lowers SellIn for every item at end of day
        [Fact]
        public void item_sellin_lowered_by_one_after_each_day()
        {
            _salesItem.UpdateQuality();

            Assert.True(_item.SellIn == 1);
        }

        //The Quality of an item is never negative
        [Fact]
        public void item_quality_is_never_negative()
        {
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

        //"Aged Brie" actually increases in Quality the older it gets
        [Fact]
        public void maturing_item_quality_increases_as_gets_older()
        {
            _salesItem.UpdateQuality();

            Assert.True(_item.Quality == 1);
        }
    }
}