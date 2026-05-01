namespace GildedRoseKata.Updaters;

/// <summary>
/// Factory responsible for mapping an item to its correct updater.
/// Any item name not explicitly matched is treated as a normal item by default.
/// </summary>
public static class ItemUpdaterFactory
{
    /// <summary>
    /// Returns the appropriate <see cref="ItemUpdater"/> for the given item,
    /// based on the item's name.
    /// </summary>
    /// <param name="item">The item to find an updater for.</param>
    /// <returns>A concrete <see cref="ItemUpdater"/> for the given item type.</returns>
    public static ItemUpdater For(Item item) => item.Name switch
    {
        "Aged Brie" => new AgedBrieUpdater(item),
        "Backstage passes to a TAFKAL80ETC concert" => new BackStagePassUpdater(item),
        "Sulfuras, Hand of Ragnaros" => new SulfurasUpdater(item),
        var n when n.StartsWith("Conjured") => new ConjuredUpdater(item),
        _ => new NormalItemUpdater(item)
    };
}
