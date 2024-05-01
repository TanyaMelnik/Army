using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class DecoratorChecker
    {
        public static void CheckDecorator(List<IUnit> army)
        {
            for (int i= 1; i < army.Count-1; i++)
            { 
                // Если нашли легкого солдата
                if (army[i] is LogGetAttack lightUnit && lightUnit.unit is LightWarrior)
                {
                    // А рядом с ним тяжелые солдаты => легкий солдат становится оруженосцем 
                    if (army[i+1] is LogGetAttack heavyUnit1 && heavyUnit1.unit is HeavyWarrior)
                    {
                        army[i + 1] = new HelmDecorator(new ShieldDecorator(new PikeDecorator(new HourseDecorator(army[i + 1], (0, 0)),(0,0)),(0,0)),(0,0));
                    }
                    if (army[i - 1] is LogGetAttack heavyUnit2 && heavyUnit2.unit is HeavyWarrior)
                    {
                        army[i - 1] = new HelmDecorator(new ShieldDecorator(new PikeDecorator(new HourseDecorator(army[i + 1], (0, 0)), (0, 0)), (0, 0)), (0, 0));
                    }
                }
            }

        }
    }
}
