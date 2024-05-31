using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    /// <summary>
    ///  Класс армии с рандомными показателями.
    ///  Строка идентификатора "T:Magic.BlackBoxArmy".
    /// </summary> 
    class BlackBoxArmy : AbstractArmyFactory
    {
        /// <summary>
        /// Метод рандомной атаки и урона.
        /// Строка идентификатора "M:Magic.BlackBoxArmy.PercentAttackAndDodge".
        /// </summary>
        protected override (int, double) PercentAttackAndDodge {
            get
            {
                Random rand = new ();
                int randomAttack = rand.Next(0, 26);
                double randomDodge = rand.NextDouble() * 0.2;
                return (randomAttack, randomDodge);
            }
        }
    }
}
