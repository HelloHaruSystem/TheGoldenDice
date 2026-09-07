# Domain TODO

Things `TheGoldenDice.Domain` needs before the room / party-creation flow
and real battles can be built in `TheGoldenDice.Server` and
`TheGoldenDice.Battle.Domain`.

## Already in progress

Visibility: these need to go from `internal` to `public` so other projects
can actually use them.

- `PlayerCharacter`, `NpcCharacter` (`Character/`)
- `Party` (`Party/`)
- `Gear` (`Gear/`)
- `Stats` (`Stats/`)
- `TecTeacher` (`Classes/`)
- `TecVest`, `Cigarette` (`Items/`)
- `GetSomeFreshAirAction`, `RegisterAbsenceAction` (`Action/`)

## P0 — needed for "join room -> create party -> inspect/leave/battle"

- **Catalogs**: a way to list all available `IClass`, all available
  `IHeadGear`/`IWeapon`, all available `IAction` — nothing enumerates
  "what exists" today.
- **Filter helper**: e.g. `GetAvailableActions(this IClass, int level)` —
  filters the action catalog using the `RequiredLevel`/`AllowedClasses`
  that already exist on `IAction`.
- **Stub bodies needed for display** (currently
  `throw new NotImplementedException()`):
  - `TecTeacher.Name`, `Description`, `GetStatsForLevel(int)`
  - `Stats.HPModifier`, `AttackPower`, `DefensePower`, `Speed`
  - `Gear.HeadSlot`, `WeaponSlot`
  - `TecVest`/`Cigarette`'s `Name`, `Description`, `Stats`
  - `BaseCharacter.GetAccumulatedStats()`
- **`CharacterFactory`** (new, lives in `Domain`) — takes a name + chosen
  class/gear/actions, validates them, computes stats via
  `GetStatsForLevel`, builds the character. Keeps creation rules in
  `Domain` instead of `Server`.
- **Party validation** — enforce 1-4 members (per the domain diagram) when
  a party gets built.

## P1 — needed for a battle to actually play out once matched

- `PlayerCharacter`/`NpcCharacter`'s `TakeDamage`/`Heal` bodies.
- `GetSomeFreshAirAction`/`RegisterAbsenceAction`'s
  `Execute(IDamageable, IDamageable, double)` bodies — this is what
  `Battle.Domain`'s `Battle.ResolveAction` is currently blocked on.

## P2 — smaller loose ends, not blocking anything above

- `RegisterAbsenceAction` implements `AllowedClasses` via explicit
  interface implementation while `GetSomeFreshAirAction` implements it
  publicly — inconsistent, should probably match.
- `TecTeacher.Equals(IClass?)` still throws (its `GetHashCode` is at least
  implemented).
- `NpcCharacter.GetTauntMessage()` still throws.
- `BaseCharacter.Loot()` still throws.

## Where NPC data comes from

NPC characters will be read from a file (format/location TBD). That
file-reading/parsing step belongs in `Server`, not `Domain` — `Domain`
has no I/O today and should stay that way. The parsed data gets fed
through the same `CharacterFactory` a player-built character goes
through, so both paths share the same validation/stat rules.
