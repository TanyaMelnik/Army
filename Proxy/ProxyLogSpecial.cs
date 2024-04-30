using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class ProxyLogSpecial : ISpecialProperty
    {
        ISpecialProperty unit;
        // Абстрактный класс записи
        const string logFilePath = "logSpecial.txt";
        public ProxyLogSpecial(ISpecialProperty unit)
        {
            this.unit = unit;
        }
        public IUnit DoSpecialProperty(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            string text = $"[{DateTime.Now}] Special Удар от {unit.GetType()}";
            Data.WriteInFile(logFilePath, text);
            return unit.DoSpecialProperty(ownArmy, enemyArmy, number);
        }
    }
}
