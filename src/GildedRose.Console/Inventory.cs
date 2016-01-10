using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Inventory
    {
        public IList<Item> Items;
        private const int MaxItemQuantity = 50;

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (!IsAgedBrie(item) && !IsBackstagePass(item))
                {
                    if (item.Quality > 0)
                    {
                        if (!IsLegendary(item))
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < MaxItemQuantity)
                    {
                        item.Quality = item.Quality + 1;

                        if (IsBackstagePass(item))
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < MaxItemQuantity)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < MaxItemQuantity)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (!IsLegendary(item))
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (!IsAgedBrie(item))
                    {
                        if (!IsBackstagePass(item))
                        {
                            if (item.Quality > 0)
                            {
                                if (!IsLegendary(item))
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < MaxItemQuantity)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }

        private bool IsAgedBrie(Item item)
        {
            // includes all items that increase in quality as they increase in age
            return item.Name == "Aged Brie";
        }

        private bool IsLegendary(Item item)
        {
            // includes all items that never have to be sold and never decrease in quality
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private bool IsBackstagePass(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }
    }

}
