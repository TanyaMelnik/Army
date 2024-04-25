using Magic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
   
    //*/ Интерфейс для способов создания армии 
    /*abstract class UnitFactory
    {
        public abstract List<IUnit> CreateArmy(int cost);
        // Реализация метода из интерфейса
        protected IUnit CreateUnit(UnitType unitType)
        {
            // НУЖНО ПЕРЕДАВАТЬ В КОНСТРУКТОР ОБЪЕКТ setiings
            switch (unitType)
            {
                case UnitType.LightWarrior:
                    return new LightWarrior();
                case UnitType.HeavyWarrior:
                    return new HeavyWarrior();
                case UnitType.Genetic:
                    return new Genetic();
                case UnitType.Doctor:
                    return new Doctor();
                case UnitType.Bowman:
                    return new Bowman();
                default:
                    throw new ArgumentException("Invalid unit type");
            }
        }
    }*/
}
