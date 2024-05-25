using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic;

namespace Magic
{
    /// <summary>
    /// Абстрактный класс декоратора.
    /// </summary>
    /// <param name="unit">Юнит, получивший свойства.</param>
    /// <param name="persentAttackAndDodge">Процент атаки и уклонения.</param>
    public abstract class OptionDecorator(IUnit unit, (int, double) persentAttackAndDodge) : IUnit(persentAttackAndDodge)
    {
        protected IUnit unit = unit;

    }
}
