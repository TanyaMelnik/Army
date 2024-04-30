using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic;

namespace Magic
{
    interface Dead
    {
        public void DeleteUnit(List<IUnit> army, int numberUnit);
    }
    class DeadUnit
    {
        public void DeleteUnit(List<IUnit> army, int numberUnit)
        {
            army.RemoveAt(numberUnit);
        }
    }
}
