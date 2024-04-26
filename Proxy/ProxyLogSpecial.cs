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
            using (StreamWriter log = File.AppendText(logFilePath))
            {
                log.WriteLine($"[{DateTime.Now}] Special Удар от {unit.GetType()}");
            }
            return unit.DoSpecialProperty(ownArmy, enemyArmy, number);
        }
    }
}
