using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    /// <summary>
    ///  Класс атаки армии.
    ///  Строка идентификатора "T:Magic.AttackArmy".
    /// </summary> 
    class AttackArmy : AbstractArmyFactory
    {
        /// <summary>
        /// Метод атаки и урона.
        /// Строка идентификатора "M:Magic.AttackArmy.PercentAttackAndDodge".
        /// </summary>
        protected override (int, double) PercentAttackAndDodge { get => (20, 0.0); }
    }
}
