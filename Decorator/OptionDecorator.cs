using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic;

namespace Magic
{
    // Абстрактный класс декоратора
    public abstract class OptionDecorator(IUnit unit, (int, double) persentAttackAndDodge) : IUnit(persentAttackAndDodge)
    {
        protected IUnit unit = unit;

    }
}
