using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    /// <summary>
    /// Армия с супер уклонением.
    /// </summary>
    class DodgeArmy : AbstractArmyFactory
    {
        public DodgeArmy()
        {
            percentAttackAndDodge = (0, 0.3);
        }
        public override IUnit CreateLightUnit(Settings settings)
        {
            return new LightWarrior(settings, percentAttackAndDodge);
        }
        public override IUnit CreateHeavyUnitUnit(Settings settings)
        {
            return new HeavyWarrior(settings, percentAttackAndDodge);
        }
        public override IUnit CreateGeneticUnit(Settings settings)
        {
            return new Genetic(settings, percentAttackAndDodge);
        }
        public override IUnit CreateDoctorUnit(Settings settings)
        {
            return new Doctor(settings, percentAttackAndDodge);
        }
        public override IUnit CreateBowmanUnit(Settings settings)
        {
            return new Bowman(settings, percentAttackAndDodge);
        }
    }
}
