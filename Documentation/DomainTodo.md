# Domain TODO

Things `TheGoldenDice.Domain` needs before the room / party-creation flow
and real battles can be built in `TheGoldenDice.Server` and
`TheGoldenDice.Battle.Domain`. Refreshed after the `simple-game-loop` merge
to master — most of the original list is done.

## Done

- Visibility: `PlayerCharacter`, `NpcCharacter`, `Party`, `Gear`, `Stats`,
  `TecTeacher`, `TecVest`, `Cigarette`, `GetSomeFreshAirAction`,
  `RegisterAbsenceAction` are all `public` now.
- Catalogs: `ClassCatalog`, `HeadGearCatalog`, `WeaponCatalog`,
  `ActionCatalog` exist, backed by `ICatalog<T>`/`ICatalogItem`
  (`Common/`). Hardcoded for now (each has a `// TODO: discover via
  reflection` note) — reflection wasn't viable while actions took
  constructor args; now that they don't, it's revisitable.
- `Stats.HPModifier`/`AttackPower`/`DefensePower`/`Speed` — real.
- `PlayerCharacter`/`NpcCharacter`'s `TakeDamage`/`Heal` — real.
- `BaseCharacter.GetAccumulatedStats()` and `LootThisCharacter()`
  (renamed from `Loot()`) — real, but see the blocker below.
- `TecTeacher.Name`/`Description`/`Equals`/`GetHashCode`,
  `TecVest`/`Cigarette`'s `Name`/`Description`,
  `NpcCharacter.GetTauntMessage()`, `Party.Characters` — all real.
- `RegisterAbsenceAction`'s `AllowedClasses` inconsistency — fixed.
- `Gear.HeadSlot`/`WeaponSlot` — real plain `{ get; set; }` now (kept
  public on purpose: `IGear` requires public accessors, and
  `BaseCharacter.LootThisCharacter()` sets them through the `IGear`-typed
  `Gear` property, so a private setter would both fail to compile and
  break that method). This unblocks `Gear.GetAccumulatedStats()` and
  `LootThisCharacter()` to actually run.

## Also still stubbed (deliberately left, not a mistake)

- `TecTeacher.GetStatsForLevel(int)` — no stat-scaling formula decided
  yet.
- `TecVest.Stats` / `Cigarette.Stats` — no stat point values decided yet.

Both feed into `BaseCharacter.GetAccumulatedStats()`, so that method is
still blocked by these even though the `Gear` side is fixed.

## Blocks Battle.Domain

- `GetSomeFreshAirAction`/`RegisterAbsenceAction`'s
  `Execute(IDamageable, IDamageable, double)` bodies — still throw. This
  is what `Battle.Domain`'s `Battle.ResolveAction` needs to stop being a
  stub.

## A real bug, found via the compiler

- `BaseCharacter.GetAccumulatedStats()` calls
  `_class.GetStatsForLevel(level)` using the captured constructor
  parameter, not `this.Level` — flagged by the compiler itself
  (`CS9124`). Effect: once a character levels up, `GetAccumulatedStats()`
  keeps computing off the original construction-time level forever.

## Deferred on purpose

- `CharacterFactory`/`ICharacterFactory` — built, then deleted ("we'll do
  those later"). `ICharacterFactory.cs` is currently an orphaned
  interface with no implementation.
- `IPartyFactory`/`PartyFactory` — still present, unclear if these are
  meant to be deferred too or kept as-is.

## Server work, blocked on the above

- `RoomHub.JoinRoomAsync` — stub, needs a character factory and a
  party-creation flow design (join room, build party from catalog
  options, inspect/leave/battle).
- `RoomWorker.Match` — stub, needs the actual matchmaking/NPC-fallback
  algorithm.

## Where NPC data comes from

NPC characters will be read from a file (format/location TBD). That
file-reading/parsing step belongs in `Server`, not `Domain` — `Domain`
has no I/O today and should stay that way. The parsed data gets fed
through the same character-creation path a player-built character goes
through, so both share the same validation/stat rules.

## Cosmetic, not blocking anything

- `CS0108` warnings on `IClass`/`IItem`/`IAction` (each redeclares
  `Name`/`Description` alongside `: ICatalogItem`, by choice) — could add
  `new` to each to silence them; never confirmed whether that's wanted.
