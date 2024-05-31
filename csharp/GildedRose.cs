using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach(Item item in Items)
            {
                item.SellIn--;
                switch (item.Name)
                {
                    case "Aged Brie":
                        UpdateAgedBrie(item);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateBackstagePasses(item);
                        break;
                    default:
                        if (item.Name.Contains("Conjured"))
                            UpdateConjuredItem(item);
                        else
                            UpdateNormalItem(item);
                        break;
                }
            }

        }

        private void UpdateAgedBrie(Item item)
        {
            item.Quality = Math.Min(50, item.Quality + 1);
            if (item.SellIn < 0)
                item.Quality = Math.Min(50, item.Quality + 1);
        }

        private void UpdateBackstagePasses(Item item)
        {
            if (item.SellIn < 0)
                item.Quality = 0;
            else if (item.SellIn < 6)
                item.Quality = Math.Min(50, item.Quality + 3);
            else if (item.SellIn < 11)
                item.Quality = Math.Min(50, item.Quality + 2);
            else
                item.Quality = Math.Min(50, item.Quality + 1);
        }

        private void UpdateConjuredItem(Item item)
        {
            item.Quality = Math.Max(0, item.Quality - 2);
            if (item.SellIn < 0)
                item.Quality = Math.Max(0, item.Quality - 2);
        }

        private void UpdateNormalItem(Item item)
        {
            item.Quality = Math.Max(0, item.Quality - 1);
            if (item.SellIn < 0)
                item.Quality = Math.Max(0, item.Quality - 1);
        }
    }
}
