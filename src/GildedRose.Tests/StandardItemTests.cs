using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class StandardItemTests
    {
        private Item _item;
        private SalesItem _salesItem;
        
        public StandardItemTests()
        {
            _item = TestItems.StandardItem;
            _salesItem = SalesItemFactory.Create(_item);
        }
        
        //system lowers Quality for every item at end of day
        [Fact]
        public void item_quality_lowered_by_one_after_each_day()
        {
            _salesItem.UpdateQuality();
            
            Assert.True(_item.Quality == 19);
        }

        //system lowers SellIn for every item at end of day
        [Fact]
        public void item_sellin_lowered_by_one_after_each_day()
        {
            _salesItem.UpdateQuality();

            Assert.True(_item.SellIn == 9);
        }

        //Once the sell by date has passed, Quality degrades twice as fast
        [Fact]
        public void item_quality_degrades_twice_as_fast_if_sell_by_date_passed()
        {
            _item.SellIn = 0;

            _salesItem.UpdateQuality();

            Assert.True(_item.Quality == 18);
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
    }
}