using Magic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BusinessLogic
{
    /// <summary>
    /// Базовый класс абстрактной фабрики, которая создаёт связанные между собой unit. 
    /// </summary>
    abstract class ArmyFactory
    {
        /// <summary>
        /// Показатель увеличения текущих показателей силы и уклонения.
        /// </summary>
        public (int, double) percentAttackAndDodge;
        public abstract IUnit CreateLightUnit(Settings settings, (int, double) percentAttackAndDodge);
        public abstract IUnit CreateHeavyUnitUnit(Settings settings, (int, double) percentAttackAndDodge);
        public abstract IUnit CreateGeneticUnit(Settings settings,(int, double) percentAttackAndDodge);
        public abstract IUnit CreateDoctorUnit(Settings settings, (int, double) percentAttackAndDodge);
        public abstract IUnit CreateBowmanUnit(Settings settings, (int, double) percentAttackAndDodge);
    }
    /// <summary>
    /// Армия с супер уклонением.
    /// </summary>
    class DodgeArmy : ArmyFactory
    {
        public DodgeArmy()
        {
            percentAttackAndDodge = (0, 0.3);
        }
        public override IUnit CreateBowmanUnit(Settings settings, (int, double) percentAttackAndDodge)
        {
            throw new NotImplementedException();
        }

        public override IUnit CreateDoctorUnit(Settings settings, (int, double) percentAttackAndDodge)
        {
            throw new NotImplementedException();
        }

        public override IUnit CreateGeneticUnit(Settings settings, (int, double) percentAttackAndDodge)
        {
            throw new NotImplementedException();
        }

        public override IUnit CreateHeavyUnitUnit(Settings settings, (int, double) percentAttackAndDodge )
        {
            throw new NotImplementedException();
        }

        public override IUnit CreateLightUnit(Settings settings, (int, double) percentAttackAndDodge)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Армия с супер атакой
    /// </summary>
    class AttackArmy : ArmyFactory
    {
        public AttackArmy()
        {
            percentAttackAndDodge = (20, 0.0);
        }
        public override IUnit CreateBowmanUnit(Settings settings, (int, double) percentAttackAndDodge)
        {
            throw new NotImplementedException();
        }

        public override IUnit CreateDoctorUnit(Settings settings, (int, double) percentAttackAndDodge)
        {
            throw new NotImplementedException();
        }

        public override IUnit CreateGeneticUnit(Settings settings, (int, double) percentAttackAndDodge)
        {
            throw new NotImplementedException();
        }

        public override IUnit CreateHeavyUnitUnit(Settings settings, (int, double) percentAttackAndDodge)
        {
            throw new NotImplementedException();
        }

        public override IUnit CreateLightUnit(Settings settings, (int, double) percentAttackAndDodge)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Армия с рандомными показателями.
    /// </summary>
    class BlackBoxArmy : ArmyFactory
    {
        public BlackBoxArmy()
        {
            Random rand = new Random();
            int randomAttack = rand.Next(0, 26);
            double randomDodge = rand.NextDouble() * 0.6 ;
            percentAttackAndDodge = (randomAttack, randomDodge);
        }
        public override IUnit CreateBowmanUnit(Settings settings, (int, double) percentAttackAndDodge)
        {
            throw new NotImplementedException();
        }

        public override IUnit CreateDoctorUnit(Settings settings, (int, double) percentAttackAndDodge)
        {
            throw new NotImplementedException();
        }

        public override IUnit CreateGeneticUnit(Settings settings, (int, double) percentAttackAndDodge)
        {
            throw new NotImplementedException();
        }

        public override IUnit CreateHeavyUnitUnit(Settings settings, (int, double) percentAttackAndDodge)
        {
            throw new NotImplementedException();
        }

        public override IUnit CreateLightUnit(Settings settings, (int, double) percentAttackAndDodge)
        {
            throw new NotImplementedException();
        }
    }
    
    /*interface IUnitFactory
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
}
