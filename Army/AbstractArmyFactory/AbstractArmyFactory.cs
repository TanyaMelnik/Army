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
        protected abstract (int, double) PercentAttackAndDodge { get; }
        public IUnit CreateLightUnit() {
            return new LogGetAttack(new LightWarrior(PercentAttackAndDodge), PercentAttackAndDodge);
        }
        public IUnit CreateHeavyUnitUnit() {
            return new LogGetAttack(new HeavyWarrior(PercentAttackAndDodge), PercentAttackAndDodge);
        }
        public IUnit CreateGeneticUnit() {
            return new LogGetAttack(new Genetic(PercentAttackAndDodge), PercentAttackAndDodge);
        }
        public IUnit CreateDoctorUnit()
        {
            return new LogGetAttack(new Doctor(PercentAttackAndDodge), PercentAttackAndDodge);
        }
        public IUnit CreateBowmanUnit()
        {
            return new LogGetAttack(new Bowman(PercentAttackAndDodge), PercentAttackAndDodge);
        }
        public IUnit CreateGulyayGorodUnit()
        {
            return new LogGetAttack(new AdapterGulyayGorod((0,0)), (0, 0));
        }
    }
}
