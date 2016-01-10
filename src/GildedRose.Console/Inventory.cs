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
                var itemName = item.Name;

                if (!IsMaturing(itemName) && !IsDeadlined(itemName))
                {
                    if (item.Quality > 0)
                    {
                        if (!IsLegendary(item.Name))
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

                        if (IsDeadlined(itemName))
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

                if (!IsLegendary(itemName))
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (!IsMaturing(itemName))
                    {
                        if (!IsDeadlined(itemName))
                        {
                            if (item.Quality > 0)
                            {
                                if (!IsLegendary(itemName))
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

        private bool IsMaturing(string itemName)
        {
            // includes all items that increase in quality as they increase in age
            return itemName == "Aged Brie";
        }

        private bool IsLegendary(string itemName)
        {
            // includes all items that never have to be sold and never decrease in quality
            return itemName == "Sulfuras, Hand of Ragnaros";
        }

        private bool IsDeadlined(string itemName)
        {
            return itemName == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool IsConjured(string itemName)
        {
            return itemName == "Conjured Mana Cake";
        }
    }

}
