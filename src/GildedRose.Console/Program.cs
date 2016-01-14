using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            IList<Item> Items;

            Items = new List<Item>
                        {
                            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                        };

            foreach (var item in Items)
            {
                var i = SalesItemFactory.Create(item);

                //System.Console.WriteLine(string.Format("BEFORE UPDATE - Type: {0}, Name: {1}, SellIn: {2}, Quality: {3}", i.GetType().Name, i.Name, i.SellIn, i.Quality));

                i.UpdateQuality();

                //System.Console.WriteLine(string.Format("AFTER UPDATE  - Type: {0}, Name: {1}, SellIn: {2}, Quality: {3}\r\n", i.GetType().Name, i.Name, i.SellIn, i.Quality));
            }

            System.Console.ReadKey();
        }
    }

}