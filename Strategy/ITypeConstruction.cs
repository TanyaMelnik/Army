using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    interface ITypeConstruction
    {
        // Ближний бой
        void MakeMeleeFight(List<IUnit> army1, List<IUnit> army2);
        // Специальные свойства
        void DoSpecialProperties(List<IUnit> army1, List<IUnit> army2);
        // Проверка убитых солдат
        void Update(List<IUnit> army);
        // Состав армии 
        void Show(List<IUnit> army1, List<IUnit> army2);
    }
}
