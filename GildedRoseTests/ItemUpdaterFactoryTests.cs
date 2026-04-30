using GildedRoseKata;
using GildedRoseKata.Updaters;
using System;
using Xunit;

namespace GildedRoseTests;
public class ItemUpdaterFactoryTests
{
    [Theory]
    [InlineData("Aged Brie", typeof(AgedBrieUpdater))]
    [InlineData("Sulfuras, Hand of Ragnaros", typeof(SulfurasUpdater))]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", typeof(BackStagePassUpdater))]
    [InlineData("Conjured Mana Cake", typeof(ConjuredUpdater))]
    [InlineData("Conjured Banana Cake", typeof(ConjuredUpdater))]
    [InlineData("Normal Item", typeof(NormalItemUpdater))]
    [InlineData("+5 Dexterity Vest", typeof(NormalItemUpdater))]
    [InlineData("Elixir of the Mongoose", typeof(NormalItemUpdater))]
    public void Factory_ReturnsCorrectUpdater_ForEachItemName(string name, Type expectedType)
    {
        var item = new Item { Name = name, SellIn = 5, Quality = 10 };
        var updater = ItemUpdaterFactory.For(item);
        Assert.IsType(expectedType, updater);
    }
}
