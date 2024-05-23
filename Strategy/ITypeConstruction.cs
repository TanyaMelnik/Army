using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    interface ITypeConstruction
    {
        public List<IUnit> Army1 { get; set; }
        public List<IUnit> Army2 { get; set; }
        // Ближний бой
        void MakeMeleeFight();
        // Специальные свойства
        void DoSpecialProperties();
        // Проверка убитых солдат
        void Update(List<IUnit> army);
        // Проверка на декораторы
        void CheckDecorator();
        // Состав армии 
        string Show();
    }
}
