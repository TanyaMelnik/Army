using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    /// <summary>
    ///  Класс армии.
    ///  Строка идентификатора "T:Magic.IUnit".
    /// </summary> 
    abstract class AbstractArmyFactory
    {
        /// <summary>
        /// Метод, показывающий увеличения текущих показателей силы и уклонения.
        /// Строка идентификатора "M:Magic.AbstractArmyFactory.PercentAttackAndDodge".
        /// </summary>
        protected abstract (int, double) PercentAttackAndDodge { get; }

        /// <summary>
        /// Метод создания легкого воина.
        /// Строка идентификатора "M:Magic.AbstractArmyFactory.CreateLightUnit".
        /// </summary>
        /// <returns>Значение, обозначающее атаку и уклонение.</returns>
        public IUnit CreateLightUnit() {
            return new LogGetAttack(new LightWarrior(PercentAttackAndDodge), PercentAttackAndDodge);
        }

        /// <summary>
        /// Метод создания тяжелого воина.
        /// Строка идентификатора "M:Magic.AbstractArmyFactory.CreateHeavyUnit".
        /// </summary>
        /// <returns>Значение, обозначающее атаку и уклонение.</returns>
        public IUnit CreateHeavyUnit() {
            return new LogGetAttack(new HeavyWarrior(PercentAttackAndDodge), PercentAttackAndDodge);
        }

        /// <summary>
        /// Метод создания воина.
        /// Строка идентификатора "M:Magic.AbstractArmyFactory.CreateGeneticUnit".
        /// </summary>
        /// <returns>Значение, обозначающее атаку и уклонение.</returns>
        public IUnit CreateGeneticUnit() {
            return new LogGetAttack(new Genetic(PercentAttackAndDodge), PercentAttackAndDodge);
        }

        /// <summary>
        /// Метод создания доктора.
        /// Строка идентификатора "M:Magic.AbstractArmyFactory.CreateDoctorUnit".
        /// </summary>
        /// <returns>Значение, обозначающее атаку и уклонение.</returns>
        public IUnit CreateDoctorUnit()
        {
            return new LogGetAttack(new Doctor(PercentAttackAndDodge), PercentAttackAndDodge);
        }

        /// <summary>
        /// Метод создания лучника.
        /// Строка идентификатора "M:Magic.AbstractArmyFactory.CreateBowmanUnit".
        /// </summary>
        /// <returns>Значение, обозначающее атаку и уклонение.</returns>
        public IUnit CreateBowmanUnit()
        {
            return new LogGetAttack(new Bowman(PercentAttackAndDodge), PercentAttackAndDodge);
        }

        /// <summary>
        /// Метод создания Гуляй Города.
        /// Строка идентификатора "M:Magic.AbstractArmyFactory.CreateGulyayGorodUnit.
        /// </summary>
        /// <returns>Значение, обозначающее адаптер Гуляй Города.</returns>
        public IUnit CreateGulyayGorodUnit()
        {
            return new LogGetAttack(new AdapterGulyayGorod((0,0)), (0, 0));
        }
    }
}
