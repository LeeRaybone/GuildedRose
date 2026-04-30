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

## Design Decisions

### Updater Pattern
Each item type has its own dedicated updater class, all inheriting 
from an abstract `ItemUpdater` base class. This replaces the original 
deeply nested if/else chain with focused, readable classes.

Adding a new item type in future requires:
1. A new updater class
2. One new line in the factory

No existing code needs to be touched.

### Why Abstract Class Over Interface?
The abstract base class provides two shared helper methods used by 
all updaters:
- `DecrementSellIn()` — decrements SellIn by 1
- `AdjustQuality(int amount)` — adjusts quality while enforcing the 
  0-40 cap via Math.Clamp

An interface would mean every updater reimplementing this logic 
individually.

### Factory
`ItemUpdaterFactory` is responsible for mapping an item to its 
correct updater. It uses a C# switch expression for clarity. 
Any item whose name is not explicitly matched is treated as a 
normal item by default.

### Quality Cap
The original code used 50 as the quality cap. The requirements 
specification states 40. This solution enforces 40, with Sulfuras 
being the only exception as a legendary item fixed at 80.

### Backstage Pass Boundaries
The original code had an off-by-one bug in the quality threshold 
logic due to incrementing quality before checking thresholds. This 
has been corrected in the refactor. Tests document the correct 
behaviour as per the spec:
- SellIn > 7: quality increases by 1
- SellIn <= 7: quality increases by 3
- SellIn <= 2: quality increases by 4
- SellIn < 0: quality drops to 0

### Conjured Items
`ConjuredUpdater` handles any item whose name starts with "Conjured", 
making it flexible for any future conjured items beyond "Conjured 
Mana Cake". It degrades at double the normal rate, capped at 0.

---

## Bugs Found in Original Code

| Bug | Decision |
|-----|----------|
| Quality cap was 50, spec says 40 | Fixed — corrected per spec cap set to 40 |
| Backstage pass thresholds off was 5 and 10 | Fixed — corrected per spec to 7 and 3 |
| `Quality = Quality - Quality` instead of `Quality = 0` | Fixed — cleaned up in refactor |

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
 
Tests cover the following for each item type:
- SellIn decrements correctly
- Quality changes at the correct rate
- Quality never drops below 0
- Quality never exceeds 40 (except Sulfuras)
- All boundary conditions for Backstage Passes
- Factory routes every item name to the correct updater