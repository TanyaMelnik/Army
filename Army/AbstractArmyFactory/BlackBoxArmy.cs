using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    /// <summary>
    /// Армия с рандомными показателями.
    /// </summary>
    class BlackBoxArmy : AbstractArmyFactory
    {
        protected override (int, double) PercentAttackAndDodge {
            get
            {
                Random rand = new Random();
                int randomAttack = rand.Next(0, 26);
                double randomDodge = rand.NextDouble() * 0.6;
                return (randomAttack, randomDodge);
            }
        }
    }
}
