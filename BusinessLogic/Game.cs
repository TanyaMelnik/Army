using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    public enum UnitType
    {
        LightWarrior,
        HeavyWarrior,
        Genetic,
        Doctor,
        Bowman
    }
    // Интерфейс для способов создания армии 
    abstract class UnitFactory 
    {
        public abstract List<IUnit> CreateArmy(int cost);
        // Реализация метода из интерфейса
        protected IUnit CreateUnit(UnitType unitType)
        {
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
    }
    // Создание конкретных классов видов
    class RandomUnit : IUnitFactory
    {
        public readonly Random random = new();

         List<IUnit> CreateArmy(int cost)
        {
            List<IUnit> army = new();

            while (cost > 0)
            {
                // Выбираем случайный тип юнита
                UnitType randomUnitType = (UnitType)random.Next(Enum.GetNames(typeof(UnitType)).Length);
                IUnit unit = CreateUnit(randomUnitType);

                // Добавляем юнита в армию и вычитаем его стоимость из общих затрат
                army.Add(unit);
                cost -= unit.GetCost();
            }

            return army;
        }

    }

    public class BalancedUnit : IUnitFactory
    {
        public readonly Dictionary<UnitType, double> unitCost;

        // Изменяем доступность возвращаемого значения на публичную
        public List<IUnit> CreateArmy(int cost)
        {
            List<IUnit> army = new List<IUnit>();

            // Сортируем типы юнитов по их стоимости
            var sortedUnitTypes = unitCost.OrderBy(pair => pair.Value).ToList();

            foreach (var pair in sortedUnitTypes)
            {
                while (cost >= pair.Value)
                {
                    IUnit unit = CreateUnit(pair.Key);
                    army.Add(unit);
                    cost -= (int)pair.Value;
                }
            }

            return army;
        }

        public IUnit CreateUnit(UnitType unitType)
        {
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
    }
    // Сначала дорогие, потом дешёвые 
    public class FirstCostly : IUnitFactory
    {

        public List<IUnit> CreateArmy(int cost)
        {
            List<IUnit> army = new();
            return army;
        }

        public IUnit CreateUnit(UnitType unitType)
        {
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

    }
    // Абстрактная фабрика для создания конкретных объектов. 
    interface IIWayMakeFactory
    {
        // Фабричный метод, создает объекты IUnitFactory
        IUnitFactory CreateWay();
    }
    // Фабрики для создания видов создания
    class RandomUnitFactory : IIWayMakeFactory
    {
        public IUnitFactory CreateWay()
        {
            return new RandomUnit();
        }
    }
    class FirstCostlyFactory : IIWayMakeFactory
    {
        public IUnitFactory CreateWay()
        {
            return new BalancedUnit();
        }
    }
    class BalancedUnitFactory : IIWayMakeFactory
    {
        public IUnitFactory CreateWay()
        {
            return new FirstCostly();
        }
    }
    public class Game
    {
        public readonly IUnitFactory unitFactory;

        public Game(IUnitFactory unitFactory)
        {
            this.unitFactory = unitFactory;
        }

        // Делаем метод CreateArmy публичным
        public List<IUnit> ChooseMethod(int cost)
        {
            return unitFactory.CreateArmy(cost);
        }
    }

}