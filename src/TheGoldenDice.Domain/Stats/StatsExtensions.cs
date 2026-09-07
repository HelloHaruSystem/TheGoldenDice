using System;
using System.Collections.Generic;
using System.Text;

namespace TheGoldenDice.Domain.Stats
{
    public static class StatsExtensions
    {
        public static IStats Plus(this IStats a, IStats b)
        {
            return new Stats()
            {
                AttackPower = a.AttackPower + b.AttackPower,
                DefensePower = a.DefensePower + b.DefensePower,
                HPModifier = a.HPModifier + b.HPModifier,
                Speed = a.Speed + b.Speed
            };
        }
    }
}
