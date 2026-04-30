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
    [InlineData(7)]
    [InlineData(6)]
    [InlineData(5)]
    [InlineData(4)]
    [InlineData(3)]
    public void QualityIncreasesByTwo_WhenSellInBetweenSevenAndThree(int sellIn)
    {
        var item = new Item { Name = BackstagePassName, SellIn = sellIn, Quality = 20 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(23, item.Quality);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(1)]
    public void QualityIncreasesByThree_WhenSellInTwoOrBelow(int sellIn)
    {
        var item = new Item { Name = BackstagePassName, SellIn = sellIn, Quality = 20 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(24, item.Quality);
    }

    [Fact]
    public void QualityDropsToZero_AfterConcert()
    {
        var item = new Item { Name = BackstagePassName, SellIn = 0, Quality = 40 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(0, item.Quality);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(1)]
    public void QualityNeverExceedsForty_WhenSellInIsTwoOrBelow(int sellIn)
    {
        var item = new Item { Name = BackstagePassName, SellIn = sellIn, Quality = 38 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(40, item.Quality);
    }


    [Theory]
    [InlineData(7)]
    [InlineData(6)]
    [InlineData(5)]
    [InlineData(4)]
    [InlineData(3)]
    public void QualityNeverExceedsForty_WhenSellInIsBetweenSevenAndThree(int sellIn)
    {
        var item = new Item { Name = BackstagePassName, SellIn = sellIn, Quality = 39 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(40, item.Quality);
    }

    [Fact]
    public void QualityNeverExceedsForty_WhenSellInIsAboveSeven()
    {
        var item = new Item { Name = BackstagePassName, SellIn = 10, Quality = 39 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(40, item.Quality);
    }
}

