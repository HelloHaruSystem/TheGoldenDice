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
- `Gear.HeadSlot`/`WeaponSlot` — real plain `{ get; set; }` (kept public
  on purpose: `IGear` requires public accessors, and
  `BaseCharacter.LootThisCharacter()` sets them through the `IGear`-typed
  `Gear` property, so a private setter would fail to compile).
- `TecTeacher.Name`/`Description`/`Equals`/`GetHashCode`,
  `TecVest`/`Cigarette`'s `Name`/`Description`,
  `NpcCharacter.GetTauntMessage()`, `Party.Characters` — all real.
- `RegisterAbsenceAction`'s `AllowedClasses` inconsistency — fixed.
- `TecTeacher.GetStatsForLevel(int)` — real: a private base-stats
  constant (`HP 10, Attack 3, Defense 2, Speed 5`) scaled linearly by
  `level`.
- `TecVest.Stats` (`+1 HPModifier`, `+2 DefensePower`) and
  `Cigarette.Stats` (`-1 HPModifier`, `+2 AttackPower`) — real.
- `BaseCharacter.GetAccumulatedStats()` and `LootThisCharacter()`
  (renamed from `Loot()`) — real, and everything they depend on
  (`Gear`'s slots, `TecTeacher.GetStatsForLevel`, item `Stats`) is real
  too now, so both run end-to-end.
- `GetSomeFreshAirAction`/`RegisterAbsenceAction`'s `Execute` bodies —
  real. `IAction.Execute` changed from `(IDamageable actor, IDamageable
  victim, double modifier)` to `(IDamageable actor,
  IReadOnlyList<IDamageable> targets, double modifier)` — needed since
  `RegisterAbsenceAction` hits the whole enemy party, not one target.
  `GetSomeFreshAirAction` heals `actor` for a flat 5, ignoring
  `targets`/`modifier`. `RegisterAbsenceAction` deals a flat 2 damage to
  every entry in `targets`, scaled by `modifier`. All placeholder
  numbers, not balance. `Battle.Domain` doesn't call `Execute` anywhere
  yet (`Battle.ResolveAction` is still its own stub) — its eventual
  implementation will need to build a `targets` list (the opposing
  party's `IDamageable`s) before calling this.

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

- `CS0108` warnings on `IItem` (`Name`/`Description` redeclared alongside
  `: ICatalogItem`, by choice) — could add `new` to silence them; never
  confirmed whether that's wanted. `IClass`/`IAction` had their
  redundant redeclarations cleaned up already.
