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
    public class HourseDecorator : OptionDecorator
    {
        public HourseDecorator(IUnit unit, (int, double) persentAttackAndDodge):base (unit, persentAttackAndDodge)
        {
            // Характеристики опции.
            attack = 25;
            defense =  20;
            name = unit.Name() + " с конём";
        }
        // Подправить имя
        public override string Name() => name;
        public override int Attack() => unit.Attack() + attack;
        public override int Defense() => unit.Defense() + defense;
        public override double Dodge() => unit.Dodge();
        public override int Cost() => unit.Cost();
        public override void GetHit(int strengthAttack)
        {
            // Если опция сбивается 
            if (strengthAttack - defense >= 0)
            {
                unit.GetHit(strengthAttack - defense);
                // Убираем опцию
                defense = 0;
                attack = 0;
                name = unit.Name();
            }
            else
            {
                defense -= strengthAttack;
            }
        }
        public override int Health()=>unit.Health();
        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {Health()} Сила: {Attack()} Стоимость: {Cost()} Броня {Defense()} Уклонение {Dodge()}");
        }
       
    }
    // Конкретные декораторы - пика
    public class PikeDecorator : OptionDecorator
    {
        public PikeDecorator(IUnit unit, (int, double) persentAttackAndDodge) : base(unit, persentAttackAndDodge)
        {
            // Характеристики опции.
            attack = 15;
            defense = 10;
            name = unit.Name() + " с пикой";
        }
        // Подправить имя
        public override string Name() => name;
        public override int Attack() => unit.Attack() + attack;
        public override int Defense() => unit.Defense() + defense;
        public override double Dodge() => unit.Dodge();
        public override int Health() => unit.Health();
        public override void GetHit(int strengthAttack)
        {
            // Если опция сбивается 
            if (strengthAttack - defense >= 0)
            {
                unit.GetHit(strengthAttack - defense);
                // Убираем опцию
                defense = 0;
                attack = 0;
                name = unit.Name();
            }
            else
            {
                defense -= strengthAttack;
            }
        }
        public override int Cost() => unit.Cost();
        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {Health()} Сила: {Attack()} Стоимость: {Cost()} Броня {Defense()} Уклонение {unit.Dodge}");
        }
    }
    // Конкретные декораторы - щит
    public class ShieldDecorator : OptionDecorator
    {
        public ShieldDecorator(IUnit unit, (int, double) persentAttackAndDodge) : base(unit, persentAttackAndDodge)
        {
            // Характеристики опции.
            defense = 30;
            name = unit.Name() + " с щитом";
        }
        // Подправить имя
        public override string Name() => name;
        public override int Attack() => unit.Attack();
        public override int Defense() => unit.Defense() + defense;
        public override double Dodge() => unit.Dodge();
        public override int Health() => unit.Health();
        public override int Cost() => unit.Cost();
        public override void GetHit(int strengthAttack)
        {
            // Если опция сбивается 
            if (strengthAttack - defense >= 0)
            {
                unit.GetHit(strengthAttack - defense);
                // Убираем опцию
                defense = 0;
                name = unit.Name();
            }
            else
            {
                defense -= strengthAttack;
            }
        }
        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {Health()} Сила: {Attack()} Стоимость: {Cost()} Броня {Defense()} Уклонение {Dodge()}");
        }
    }
    // Конкретные декораторы - шлем 
    public class HelmDecorator : OptionDecorator
    {
        public HelmDecorator(IUnit unit, (int, double) persentAttackAndDodge) : base(unit, persentAttackAndDodge)
        {
            // Защита опции.
            defense = 20;
            name = unit.Name() + " с шлемом";
        }
        // Подправить имя
        public override string Name() => name;
        public override int Attack() => unit.Attack();
        public override int Defense() => unit.Defense() + defense;
        public override double Dodge() => unit.Dodge();
        public override int Health() => unit.Health();
        public override int Cost() => unit.Cost();
        public override void GetHit(int strengthAttack)
        {
            // Если опция сбивается 
            if (strengthAttack - defense >= 0)
            {
                unit.GetHit(strengthAttack - defense);
                // Убираем опцию
                defense = 0;
                name = unit.Name();
            }
            else
            {
                defense -= strengthAttack;
            }
        }
        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {Health()} Сила: {Attack()} Стоимость: {Cost()} Броня {Defense()} Уклонение {Dodge()}");
        }
    }
}
