namespace GildedRoseKata.Updaters;

/// <summary>
/// Updater for Aged Brie.
/// Unlike normal items, Aged Brie increases in quality the older it gets.
/// </summary>
public class AgedBrieUpdater : ItemUpdater
{
    /// <summary>
    /// Initialises a new instance of <see cref="AgedBrieUpdater"/> with the given item.
    /// </summary>
    /// <param name="item">The Aged Brie item to be updated.</param>
    public AgedBrieUpdater(Item item) : base(item) { }

    /// <summary>
    /// Decrements SellIn by 1, then increases Quality by 1 before the sell by date,
    /// or by 2 once the sell by date has passed.
    /// Quality is clamped to a maximum of 40.
    /// </summary>
    public override void Update()
    {
        DecrementSellIn();
        AdjustQuality(Item.SellIn < 0 ? 2 : 1);
    }
}


