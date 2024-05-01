﻿using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
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