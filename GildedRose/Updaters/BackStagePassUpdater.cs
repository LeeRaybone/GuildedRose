namespace GildedRoseKata.Updaters;

/// <summary>
/// Updater for Backstage Pass items.
/// Quality increases as the concert approaches, with bonus increases
/// at 7 days and 2 days remaining. Quality drops to 0 after the concert.
/// </summary>
public class BackStagePassUpdater : ItemUpdater
{   
    /// <summary>
    /// Initialises a new instance of <see cref="BackStagePassUpdater"/> with the given item.
    /// </summary>
    /// <param name="item">The Backstage Pass item to be updated.</param>
    public BackStagePassUpdater(Item item) : base(item) { }

    /// <summary>
    /// Decrements SellIn by 1, then adjusts Quality based on how many days remain:
    /// <list type="bullet">
    ///     <item>More than 7 days remaining: Quality increases by 1</item>
    ///     <item>7 days or less remaining: Quality increases by 3</item>
    ///     <item>2 days or less remaining: Quality increases by 4</item>
    ///     <item>After the concert: Quality drops to 0</item>
    /// </list>
    /// Quality is clamped to a maximum of 40.
    /// </summary>
    public override void Update()
    {
        var increase = Item.SellIn switch
        {
            < 3 => 4,
            < 8 => 3,
            _ => 1
        };

        DecrementSellIn();

        if (Item.SellIn < 0)
        {
            Item.Quality = 0;
            return;
        }

        AdjustQuality(increase);
    }
}
