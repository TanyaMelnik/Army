using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    /// <summary>
    /// Армия с супер атакой
    /// </summary>
    class AttackArmy : AbstractArmyFactory
    {
        protected override (int, double) PercentAttackAndDodge { get => (20, 0.0); }
    }
}
