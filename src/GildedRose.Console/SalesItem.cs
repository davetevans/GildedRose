namespace GildedRose.Console
{
    public class SalesItem
    {
        private Item _item;

        public SalesItem(Item item)
        {
            _item = item;
        }

        public const int MaxItemQuantity = 50;

        public string Name
        {
            get { return _item.Name; }
            set { _item.Name = value; }
        }

        public int SellIn
        {
            get { return _item.SellIn; }
            set { _item.SellIn = value; }
        }

        public int Quality
        {
            get { return _item.Quality; }
            set { _item.Quality = value; }
        }

        public void UpdateQuality()
        {
            UpdateItemQuality();

            UpdateItemSellIn();

            if (SellIn < 0)
            {
                UpdateExpiredItemQuality();
            }
        }

        public virtual void UpdateItemQuality()
        {
        }

        public virtual void UpdateItemSellIn()
        {
        }

        public virtual void UpdateExpiredItemQuality()
        {
        }
    }
}
