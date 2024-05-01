using Magic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
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
}
