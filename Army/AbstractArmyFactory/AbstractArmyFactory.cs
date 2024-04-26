using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    abstract class AbstractArmyFactory
    {
        /// <summary>
        /// Показатель увеличения текущих показателей силы и уклонения. Фабричное свойство 
        /// </summary>
        protected abstract (int, double) PercentAttackAndDodge { get; }
        // Методы, которые создают конкретеные IUnit
        public IUnit CreateLightUnit(Settings settings) {
            return new LightWarrior(settings, PercentAttackAndDodge);
        }
        public IUnit CreateHeavyUnitUnit(Settings settings) {
            return new HeavyWarrior(settings, PercentAttackAndDodge);
        }
        public IUnit CreateGeneticUnit(Settings settings) {
            return new Genetic(settings, PercentAttackAndDodge);
        }
        public IUnit CreateDoctorUnit(Settings settings)
        {
            return new Doctor(settings, PercentAttackAndDodge);
        }
        public IUnit CreateBowmanUnit(Settings settings)
        {
            return new Bowman(settings, PercentAttackAndDodge);
        }
    }
}
