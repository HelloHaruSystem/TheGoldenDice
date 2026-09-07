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
  yet. This is the last thing feeding into
  `BaseCharacter.GetAccumulatedStats()` that isn't real yet.

`TecVest.Stats` (`+1 HPModifier`, `+2 DefensePower`) and
`Cigarette.Stats` (`-1 HPModifier`, `+2 AttackPower`) are done.

## Done, but signature changed

- `GetSomeFreshAirAction`/`RegisterAbsenceAction`'s `Execute` bodies are
  real now. `IAction.Execute` changed from `(IDamageable actor,
  IDamageable victim, double modifier)` to `(IDamageable actor,
  IReadOnlyList<IDamageable> targets, double modifier)` — needed since
  `RegisterAbsenceAction` hits the whole enemy party, not one target.
  `GetSomeFreshAirAction` heals `actor` for a flat 5, ignoring `targets`/
  `modifier`. `RegisterAbsenceAction` deals a flat 2 damage to every
  entry in `targets`, scaled by `modifier` (meant to carry stat-based
  scaling from whoever calls `Execute`). All placeholder numbers, not
  balance. `Battle.Domain` doesn't call `Execute` anywhere yet
  (`Battle.ResolveAction` is still its own stub), so this didn't ripple
  there — but `Battle.Domain`'s eventual `ResolveAction` implementation
  will need to build a `targets` list (the opposing party's `IDamageable`s)
  before calling this.


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
