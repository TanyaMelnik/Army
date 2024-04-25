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
        /// Показатель увеличения текущих показателей силы и уклонения.
        /// </summary>
        public (int, double) percentAttackAndDodge;
        // Фабричные методы, которые создают конкретеные IUnit
        public abstract IUnit CreateLightUnit(Settings settings);
        public abstract IUnit CreateHeavyUnitUnit(Settings settings);
        public abstract IUnit CreateGeneticUnit(Settings settings);
        public abstract IUnit CreateDoctorUnit(Settings settings);
        public abstract IUnit CreateBowmanUnit(Settings setting);
    }
}
