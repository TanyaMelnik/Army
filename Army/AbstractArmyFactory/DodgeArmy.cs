using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    /// <summary>
    ///  Класс армии с супер уклонениями.
    ///  Строка идентификатора "T:Magic.DodgeArmy".
    /// </summary>
    class DodgeArmy : AbstractArmyFactory
    {
        /// <summary>
        /// Метод супер атаки и урона.
        /// Строка идентификатора "M:Magic.DodgeArmy.PercentAttackAndDodge".
        /// </summary>
        protected override (int, double) PercentAttackAndDodge { get => (0, 0.2); }
    }
}
