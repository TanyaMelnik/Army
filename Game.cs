using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    enum UnitType
    {
        LightWarrior,
        HeavyWarrior,
        Genetic,
        Doctor,
        Bowman,
    }
    // Переделать под фабрику!!!!!!!
    internal class Game
    {
        private Random random = new Random();
        public List<IUnit> CreateArmyRand(int numberOfUnits)
        {
            List<IUnit> army = new List<IUnit>();

            for (int i = 0; i < numberOfUnits; i++)
            {
                UnitType randomUnitType = (UnitType)random.Next(Enum.GetNames(typeof(UnitType)).Length);

                switch (randomUnitType)
                {
                    case UnitType.LightWarrior:
                        army.Add(new LightWarrior());
                        break;
                    case UnitType.HeavyWarrior:
                        army.Add(new HeavyWarrior());
                        break;
                    case UnitType.Genetic:
                        army.Add(new Genetic());
                        break;
                    case UnitType.Doctor:
                        army.Add(new Doctor());
                        break;
                    case UnitType.Bowman:
                        army.Add(new Bowman());
                        break;
                
                }
            }

            return army;
        }
    }
}
