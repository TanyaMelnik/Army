using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic 
{
    // Абстрактный класс декоратора
    public abstract class OptionDecorator(IUnit unit,(int,double)persentAttackAndDodge) : IUnit(persentAttackAndDodge)
    {
        protected IUnit unit = unit;
     
    }
    // Конкретные декораторы - конь
    public class HourseDecorator(IUnit unit, (int, double) persentAttackAndDodge) : OptionDecorator(unit, persentAttackAndDodge)
    {
        public override int Attack()
        {
            throw new NotImplementedException();
        }

        public override void GetHit(int strengthAttack)
        {
            throw new NotImplementedException();
        }

        public override int Health()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
    // Конкретные декораторы - пика
    public class PikeDecorator(IUnit unit, (int, double) persentAttackAndDodge) : OptionDecorator(unit, persentAttackAndDodge)
    {
        public override int Attack()
        {
            throw new NotImplementedException();
        }

        public override void GetHit(int strengthAttack)
        {
            throw new NotImplementedException();
        }

        public override int Health()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
    // Конкретные декораторы - шит
    public class ShieldDecorator(IUnit unit, (int, double) persentAttackAndDodge) : OptionDecorator(unit, persentAttackAndDodge)
    {
        public override int Attack()
        {
            throw new NotImplementedException();
        }

        public override void GetHit(int strengthAttack)
        {
            throw new NotImplementedException();
        }

        public override int Health()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
    // Конкретные декораторы - щит 
    public class HelmDecorator(IUnit unit, (int, double) persentAttackAndDodge) : OptionDecorator(unit, persentAttackAndDodge)
    {
        public override int Attack()
        {
            throw new NotImplementedException();
        }

        public override void GetHit(int strengthAttack)
        {
            throw new NotImplementedException();
        }

        public override int Health()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
