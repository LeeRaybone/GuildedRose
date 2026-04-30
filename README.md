# Gilded Rose — C# Refactoring Solution - Lee Raybone

## Build the project

Use your normal build tools to build the projects in Debug mode.
For example, you can use the `dotnet` command line tool:

``` cmd
dotnet build GildedRose.sln -c Debug
```

## Run the Gilded Rose Command-Line program

For e.g. 10 days:

``` cmd
GildedRose/bin/Debug/net8.0/GildedRose 10
```

## Run all the unit tests

``` cmd
dotnet test
```

---
 
## My Approach
 
When I first looked at the original `UpdateQuality` method, it was clear that the deeply nested if/else chain was the core problem — it was doing too many things at once and would only get harder to maintain as new item types were added. My goal was to restructure the code so that each item type owns its own behaviour, and adding something new in future is as low-risk as possible.
 
---

## Design Decisions

### Updater Pattern
I gave each item type its own dedicated updater class, all inheriting from an abstract `ItemUpdater` base class. This means the logic for Aged Brie lives in `AgedBrieUpdater`, the logic for Backstage Passes lives in `BackstagePassUpdater`, and so on — rather than everything being tangled together in one place.
 
The practical benefit is that adding a new item type in future only requires:
1. A new updater class
2. One new line in the factory

Nothing else needs to be touched, which reduces the risk of breaking existing behaviour.
 

### Why Abstract Class Over Interface?
I chose an abstract base class because it lets me share two helper methods across all updaters:

- `DecrementSellIn()` — decrements SellIn by 1
- `AdjustQuality(int amount)` — adjusts quality by passing in a positive or negative integer, while automatically enforcing the 0–40 cap via `Math.Clamp`

Had I used an interface, every updater would have had to reimplement this logic individually, which felt like unnecessary repetition.

### Factory
`ItemUpdaterFactory` is responsible for deciding which updater to use for a given item. It uses a C# switch expression to keep the mapping clean and readable. Anything not explicitly matched falls through to `NormalItemUpdater` by default, which felt like the safest assumption.

### Quality Cap
The original code capped quality at 50, but the requirements specification clearly states 40. I've corrected this in the refactor. Sulfuras is the only exception — as a legendary item it sits permanently at 80 and is exempt from the cap entirely.
 

### Backstage Pass Boundaries
The original code had a couple of issues here. The threshold values didn't match the spec (it used 10 and 5, where the spec says 7 and 2), and there was an off-by-one bug caused by incrementing quality before checking the thresholds. I've corrected both. The behaviour is now:
- SellIn > 7: quality increases by 1
- SellIn <= 7: quality increases by 3
- SellIn <= 2: quality increases by 4
- SellIn < 0: quality drops to 0

### Conjured Items
Rather than matching only on "Conjured Mana Cake" by name, `ConjuredUpdater` handles any item whose name starts with "Conjured". This felt like a more sensible approach — if a second conjured item is introduced in future it will just work, without needing a factory change. This has been proven as I have added a second counjured item - "Conjured Banana Cake". Conjured items degrade at double the normal rate and are capped at 0.

---

## Bugs Found in Original Code

| Bug | What I did |
|-----|------------|
| Quality cap was 50, spec says 40 | Fixed — corrected per spec |
| Backstage pass thresholds were 5 and 10, spec says 7 and 2 | Fixed — corrected per spec |
| `Quality = Quality - Quality` instead of `Quality = 0` | Fixed — cleaned up in the refactor |

---

## Project Structure

```
GildedRose/
    Item.cs                        ← untouched as per requirements
    GildedRose.cs                  ← delegates to factory
    Program.cs                     ← simulation runner, untouched
    Updaters/
        ItemUpdater.cs             ← abstract base class
        ItemUpdaterFactory.cs      ← routes items to correct updater
        NormalItemUpdater.cs
        AgedBrieUpdater.cs
        BackstagePassUpdater.cs
        SulfurasUpdater.cs
        ConjuredUpdater.cs
GildedRose.Tests/
    GildedRoseTests.cs
    ItemUpdaterFactoryTests.cs
    AgedBrieTests.cs
    BackStagePassesTests.cs
    CounjuredItemsTests.cs
    NormalItemsTests.cs
    SulfurasTests.cs
```
 
---
 
## Test Coverage
 
I split the tests into separate files per item type to keep things focused and easy to navigate. 
Each file covers:
- SellIn decrements correctly each day
- Quality changes at the correct rate before and after the sell by date
- Quality never drops below 0
- Quality never exceeds 40 (Sulfuras excluded)
- Boundary conditions for Backstage Passes at each threshold
- The factory correctly routes every item name to the right updater