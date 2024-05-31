using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {

        [Test]
        public void UpdateQuality_AgedBrie_IncreasesQuality()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            Assert.AreEqual(21, items[0].Quality);
        }

        [Test]
        public void UpdateQuality_AgedBrie_QualityNeverExceeds50()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 49 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            Assert.AreEqual(50, items[0].Quality);
        }

        [Test]
        public void UpdateQuality_BackstagePasses_IncreasesQuality()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            Assert.AreEqual(22, items[0].Quality);
        }


        [Test]
        public void UpdateQuality_BackstagePasses_QualityNeverExceeds50()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            Assert.AreEqual(50, items[0].Quality);
        }

        [Test]
        public void UpdateQuality_BackstagePasses_QualityDropsToZeroAfterConcert()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void UpdateQuality_ConjuredItem_DecreasesQualityTwiceAsFast()
        {
            var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 20 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            Assert.AreEqual(18, items[0].Quality);
        }        

        [Test]
        public void UpdateQuality_NormalItem_DecreasesQuality()
        {
            var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 5, Quality = 20 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            Assert.AreEqual(19, items[0].Quality);
        }
    }
}
