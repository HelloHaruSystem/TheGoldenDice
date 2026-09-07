# The Golden Dice

A simple text-based game. You fight with a team of characters against
other players or computer enemies.

## How the project is split up

The code is split into 3 parts (projects). Each one has its own job.

### 1. `TheGoldenDice.Domain`

The basic game pieces: characters, classes, gear, items, stats, and
parties (teams). This part does not know anything about battles or
the server. It just describes what things *are*.

### 2. `TheGoldenDice.Battle.Domain`

The rules for a fight. It uses the pieces from `TheGoldenDice.Domain`
and adds turn-by-turn battle logic: whose turn it is, what happens
when someone acts, and when a battle is won or lost.

### 3. `TheGoldenDice.Server`

The part that actually runs and hosts the game. Players connect to
this over the network (using websockets). It handles rooms, puts
players in a queue, matches them up, and runs battles using the
`Battle.Domain` rules.

## Note

A lot of this project is still being built. Some parts are just
placeholders for now and will show a "not implemented" error if you
try to use them. This is normal at this stage.
