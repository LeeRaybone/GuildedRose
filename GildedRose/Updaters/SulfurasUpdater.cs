namespace GildedRoseKata.Updaters;

/// <summary>
/// Updater for Sulfuras, Hand of Ragnaros.
/// Sulfuras is a legendary item — its Quality and SellIn never change.
/// </summary>
public class SulfurasUpdater : ItemUpdater
{    
    /// <summary>
    /// Initialises a new instance of <see cref="SulfurasUpdater"/> with the given item.
    /// </summary>
    /// <param name="item">The Sulfuras item to be updated.</param>
    public SulfurasUpdater(Item item) : base(item) { }

    /// <summary>
    /// No update is applied. Sulfuras is a legendary item and never changes.
    /// </summary>
    public override void Update() { } //Doesn't need to do anything at this moment
}
