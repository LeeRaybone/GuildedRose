using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class BackStagePassesTests
{
    private GildedRose BuildApp(params Item[] items) => new GildedRose(new List<Item>(items));

    private const string BackstagePassName = "Backstage passes to a TAFKAL80ETC concert";

    [Fact]
    public void SellInDecreasesByOne()
    {
        var item = new Item { Name = BackstagePassName, SellIn = 15, Quality = 20 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(14, item.SellIn);
    }

    [Fact]
    public void QualityIncreasesByOne_WhenSellInAboveTen()
    {
        var item = new Item { Name = BackstagePassName, SellIn = 11, Quality = 20 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(21, item.Quality);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(7)]
    [InlineData(6)]
    public void QualityIncreasesByTwo_WhenSellInBetweenSixAndTen(int sellIn)
    {
        var item = new Item { Name = BackstagePassName, SellIn = sellIn, Quality = 20 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(22, item.Quality);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(3)]
    [InlineData(1)]
    public void QualityIncreasesByThree_WhenSellInFiveOrBelow(int sellIn)
    {
        var item = new Item { Name = BackstagePassName, SellIn = sellIn, Quality = 20 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(23, item.Quality);
    }

    [Fact]
    public void QualityDropsToZero_AfterConcert()
    {
        var item = new Item { Name = BackstagePassName, SellIn = 0, Quality = 40 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void QualityNeverExceedsFifty_NearLowerThreshold()
    {
        var item = new Item { Name = BackstagePassName, SellIn = 5, Quality = 49 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(50, item.Quality);
    }

    [Fact]
    public void QualityNeverExceedsFifty_NearUpperThreshold()
    {
        var item = new Item { Name = BackstagePassName, SellIn = 10, Quality = 49 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(50, item.Quality);
    }
}

