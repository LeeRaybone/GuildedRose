using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class AgedBrieTests
    {
    private GildedRose BuildApp(params Item[] items) =>
     new GildedRose(new List<Item>(items));

    [Fact]
    public void SellInDecreasesByOne()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(4, item.SellIn);
    }

    [Fact]
    public void QualityIncreasesByOne_BeforeSellByDate()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(11, item.Quality);
    }

    [Fact]
    public void QualityIncreasesByTwo_AfterSellByDate()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(12, item.Quality);
    }

    [Fact]
    public void QualityNeverExceedsForty()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 40 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(40, item.Quality);
    }

    [Fact]
    public void QualityNeverExceedsFifty_AfterSellByDate()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 49 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(40, item.Quality);
    }
}

