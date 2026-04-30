namespace GildedRoseKata.Updaters;

public static class ItemUpdaterFactory
{
    public static ItemUpdater For(Item item) => item.Name switch
    {
        "Aged Brie" => new AgedBrieUpdater(item),
        "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassUpdater(item),
        "Sulfuras, Hand of Ragnaros" => new SulfurasUpdater(item),
        var n when n.StartsWith("Conjured") => new ConjuredUpdater(item),
        _ => new NormalItemUpdater(item)
    };
}
