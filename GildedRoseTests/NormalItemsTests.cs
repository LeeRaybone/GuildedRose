using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class NormalItemsTests
{
    private GildedRose BuildApp(params Item[] items) =>
    new GildedRose(new List<Item>(items));


    [Fact]
    public void SellInDecreasesByOne()
    {
        var item = new Item { Name = "Normal Item", SellIn = 5, Quality = 10 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(4, item.SellIn);
    }

    [Fact]
    public void QualityDegradesByOne_BeforeSellByDate()
    {
        var item = new Item { Name = "Normal Item", SellIn = 5, Quality = 10 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(9, item.Quality);
    }

    [Fact]
    public void QualityDegradesByTwo_AfterSellByDate()
    {
        var item = new Item { Name = "Normal Item", SellIn = 0, Quality = 10 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(8, item.Quality);
    }

    [Fact]
    public void QualityNeverGoesBelowZero_BeforeSellByDate()
    {
        var item = new Item { Name = "Normal Item", SellIn = 5, Quality = 0 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void QualityNeverGoesBelowZero_AfterSellByDate()
    {
        var item = new Item { Name = "Normal Item", SellIn = 0, Quality = 1 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void QualityNeverExceedsForty()
    {
        var item = new Item { Name = "Normal Item", SellIn = 5, Quality = 40 };
        BuildApp(item).UpdateQuality();
        Assert.True(item.Quality <= 40);
    }

}
