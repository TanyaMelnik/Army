using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    /// <summary>
    /// Армия с супер уклонением.
    /// </summary>
    class DodgeArmy : AbstractArmyFactory
    {
        protected override (int, double) PercentAttackAndDodge { get => (0, 0.2); }
    }
}
