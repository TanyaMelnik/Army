using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BusinessLogic
{
    // Базовый класс фабрики. 
   /* interface IUnitFactory
    {
        // Фабричный метод, который выносит логику создания unit в особый метод
        IUnit CreateUnit(Settings settings);
    }
    class LightUnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(Settings settings)
        {
            return new LightWarrior(settings);
        }
    }
    class HeavyUnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(Settings settings)
        {
            return new HeavyWarrior(settings);
        }
    }
    class GeneticFactory : IUnitFactory
    {
        public IUnit CreateUnit(Settings settings)
        {
            return new Genetic(settings);
        }
    }
    class DoctorFactory : IUnitFactory
    {
        public IUnit CreateUnit(Settings settings)
        {
            return new Doctor(settings);
        }
    }
    class BowmanFactory : IUnitFactory
    {
        public IUnit CreateUnit(Settings settings)
        {
            return new Bowman(settings);
        }
    }*/

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
