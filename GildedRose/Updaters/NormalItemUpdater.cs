namespace GildedRoseKata.Updaters;

/// <summary>
/// Updater for normal items.
/// Quality degrades by 1 each day, and twice as fast once the sell by date has passed.
/// </summary>
public class NormalItemUpdater : ItemUpdater
{
    /// <summary>
    /// Initialises a new instance of <see cref="NormalItemUpdater"/> with the given item.
    /// </summary>
    /// <param name="item">The item to be updated.</param>
    public NormalItemUpdater(Item item) : base(item) { }

    /// <summary>
    /// Decrements SellIn by 1, then decreases Quality by 1 before the sell by date,
    /// or by 2 once the sell by date has passed.
    /// Quality is clamped to a minimum of 0.
    /// </summary>
    public override void Update()
    {
        DecrementSellIn();
        AdjustQuality(Item.SellIn < 0 ? -2 : -1);
    }
}
