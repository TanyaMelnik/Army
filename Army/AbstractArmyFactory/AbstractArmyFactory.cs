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
            return new LogGetAttack(new LightWarrior(settings, PercentAttackAndDodge), settings, PercentAttackAndDodge);
        }
        public IUnit CreateHeavyUnitUnit(Settings settings) {
            return new LogGetAttack(new HeavyWarrior(settings, PercentAttackAndDodge), settings, PercentAttackAndDodge);
        }
        public IUnit CreateGeneticUnit(Settings settings) {
            return new LogGetAttack(new Genetic(settings, PercentAttackAndDodge), settings, PercentAttackAndDodge);
        }
        public IUnit CreateDoctorUnit(Settings settings)
        {
            return new LogGetAttack(new Doctor(settings, PercentAttackAndDodge), settings, PercentAttackAndDodge);
        }
        public IUnit CreateBowmanUnit(Settings settings)
        {
            return new LogGetAttack(new Bowman(settings, PercentAttackAndDodge), settings, PercentAttackAndDodge);
        }
    }
}
