using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class SulfurasTests
{
    private GildedRose BuildApp(params Item[] items) =>new GildedRose(new List<Item>(items));

    [Fact]
    public void QualityNeverChanges()
    {
        var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(80, item.Quality);
    }

    [Fact]
    public void SellInNeverChanges()
    {
        var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(5, item.SellIn);
    }

    [Fact]
    public void SellInNeverChanges_WhenNegative()
    {
        var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(-1, item.SellIn);
    }
}

