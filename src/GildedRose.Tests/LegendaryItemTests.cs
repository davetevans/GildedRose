using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class LegendaryItemTests
    {
        private Item _item;
        private SalesItem _salesItem;

        //SellIn = 0, Quality = 80 
        public LegendaryItemTests()
        {
            _item = TestItems.LegendaryItem;
            _salesItem = SalesItemFactory.Create(_item);
        }
        
        //The Quality of an item is never negative
        [Fact]
        public void item_quality_is_never_negative()
        {
            _salesItem.UpdateQuality();

            Assert.True(_item.Quality >= 0);
        }

        //"Sulfuras", being a legendary item, never has to be sold
        [Fact]
        public void Sulfuras_never_changes_SellIn()
        {
            _salesItem.UpdateQuality();

            Assert.True(_item.SellIn == 0);
        }

        //"Sulfuras", being a legendary item, never decreases in Quality
        [Fact]
        public void Sulfuras_never_decreases_in_Quality()
        {
            _salesItem.UpdateQuality();

            Assert.True(_item.Quality == 80);
        }
    }
}