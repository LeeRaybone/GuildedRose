using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTests
{
    private GildedRose BuildApp(params Item[] items) => new GildedRose(new List<Item>(items));

    [Fact]
    public void ExampleTest()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
    }


    [Fact]
    public void MultipleItems_UpdateIndependently()
    {
        var normal = new Item { Name = "Normal Item", SellIn = 5, Quality = 10 };
        var brie = new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 };
        BuildApp(normal, brie).UpdateQuality();
        Assert.Equal(9, normal.Quality);
        Assert.Equal(11, brie.Quality);
    }

    [Fact]
    public void AnyItem_QualityNeverGoesBelowZero_WhenAlreadyAtZero()
    {
        var item = new Item { Name = "Normal Item", SellIn = 5, Quality = 0 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void AnyItem_QualityNeverExceedsFifty_WhenAlreadyAtFifty()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(50, item.Quality);
    }


}