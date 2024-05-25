using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class ProxyLogSpecial(ISpecialProperty unit) : ISpecialProperty
    {
        readonly ISpecialProperty unit = unit;
        const string logFilePath = "logSpecial.txt";

        public IUnit? DoSpecialPropertyСolumn(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            string text = $"[{DateTime.Now}] Special Удар от {unit.GetType()}";
            Data.WriteInFile(logFilePath, text);
            return unit.DoSpecialPropertyСolumn(ownArmy, enemyArmy, number);
        }

        public IUnit? DoSpecialPropertyBattalion(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            string text = $"[{DateTime.Now}] Special Удар от {unit.GetType()}";
            Data.WriteInFile(logFilePath, text);
            return unit.DoSpecialPropertyBattalion(ownArmy, enemyArmy, number);
        }

        public IUnit? DoSpecialPropertyWallToWall(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            string text = $"[{DateTime.Now}] Special Удар от {unit.GetType()}";
            Data.WriteInFile(logFilePath, text);
            return unit.DoSpecialPropertyWallToWall(ownArmy, enemyArmy, number);
        }
    }
}
