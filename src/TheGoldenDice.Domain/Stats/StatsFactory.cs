using System;
using System.Collections.Generic;
using System.Text;

namespace TheGoldenDice.Domain.Stats
{
    internal static class StatsFactory
    {
        internal static IStats Create()
        {
            return new Stats();
        }
    }
}
