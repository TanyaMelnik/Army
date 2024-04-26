using System.Reflection;
using static System.Collections.Specialized.BitVector32;

namespace Magic
{
    abstract class ArmyCreatedFactories
    {
        /// <summary>
        /// Словарь с каждым unit и их соответствующей стоимостью.
        /// </summary>
        public readonly Dictionary<Type, int> unitCost;
        // Фабрика создания unit
        protected AbstractArmyFactory army;
        protected Settings settings;
        // Фабричный метод, который создаёт армию конкретного способа
        public abstract List<IUnit> CreateArmy();
        public ArmyCreatedFactories(AbstractArmyFactory army, Settings settings) {
            // Выбираем конкретную фабрику создания unit
            this.army = army;
            this.settings = settings;
            unitCost = [];
            // Получаем текущую сборку (assembly)
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Получаем массив всех типов в текущей сборке
            Type[] unitTypes = assembly.GetTypes()
                // Фильтруем только те типы, которые являются наследниками IUnit
                .Where(t => t.IsSubclassOf(typeof(IUnit)))
                // Преобразуем результат в массив
                .ToArray();

            // Перебираем каждый найденный тип
            foreach (Type unitType in unitTypes)
            {
                // Получаем конструктор с параметрами для типа юнита
                var constructor = unitType.GetConstructor([typeof(Settings), typeof((int, double))]);
                if (constructor != null)
                {
                    // Создаем экземпляр типа, передавая параметры конструктору
                    var unitInstance = constructor.Invoke(new object[] { settings, (1, 1.0) }) as IUnit;

                    // Добавляем тип IUnit и его стоимость в словарь
                    if (unitInstance != null)
                    {
                        unitCost.Add(unitType, unitInstance.GetCost());
                    }
                }
            }
        }
        protected IUnit? CreateUnit(Type unitType)
        {
            if (unitType == typeof(LightWarrior))
            {
                return army.CreateLightUnit(settings);
            }
            else if (unitType == typeof(HeavyWarrior))
            {
                return army.CreateHeavyUnitUnit(settings);
            }
            else if (unitType == typeof(Genetic))
            {
                return army.CreateGeneticUnit(settings);
            }
            else if (unitType == typeof(Doctor))
            {
                return army.CreateDoctorUnit(settings);
            }
            else if (unitType == typeof(Bowman))
            {
                return army.CreateBowmanUnit(settings);
            }
            return null;
        }
    }
}
