﻿namespace Magic
{
    /// <summary>
    ///  Класс щита.
    ///  Строка идентификатора "T:Magic.ShieldDecorator".
    /// </summary>   
    public class ShieldDecorator : OptionDecorator
    {
        /// <summary>
        /// Метод, содержащий декоратор-щит.
        /// Строка идентификатора "M:Magic.ShieldDecorator.PikeDecorator".
        /// </summary>
        /// <param name="unit">Юнит, получивший свойства.</param>
        /// <param name="persentAttackAndDodge">Процент атаки и уклонения.</param>
        public ShieldDecorator(IUnit unit, (int, double) persentAttackAndDodge) : 
            base(unit, persentAttackAndDodge)
        {
            // Характеристики опции.
            defense = 30;
            name = unit.Name() + " с щитом";
        }

        /// <summary>
        /// Метод имени. 
        /// Строка идентификатора "M:Magic.ShieldDecorator.Name".
        /// </summary>
        public override string Name() => name ?? "";

        /// <summary>
        /// Метод атаки. 
        /// Строка идентификатора "M:Magic.ShieldDecorator.Attack".
        /// </summary>
        public override int Attack() => unit.Attack();

        /// <summary>
        /// Метод защиты. 
        /// Строка идентификатора "M:Magic.ShieldDecorator.Defense".
        /// </summary>
        public override int Defense() => unit.Defense() + defense;

        /// <summary>
        /// Метод урона. 
        /// Строка идентификатора "M:Magic.ShieldDecorator.Dodge".
        /// </summary>
        public override double Dodge() => unit.Dodge();

        /// <summary>
        /// Метод здоровья. 
        /// Строка идентификатора "M:Magic.ShieldDecorator.Health".
        /// </summary>
        public override int Health() => unit.Health();

        /// <summary>
        /// Метод стоимости. 
        /// Строка идентификатора "M:Magic.ShieldDecorator.Cost".
        /// </summary>
        public override int Cost() => unit.Cost();

        /// <summary>
        /// Метод получения удара. 
        /// Строка идентификатора "M:Magic.ShieldDecorator.GetHit(Magic.int)".
        /// </summary>
        public override void GetHit(int strengthAttack)
        {
            // Если опция сбивается. 
            if (strengthAttack - defense >= 0)
            {
                unit.GetHit(strengthAttack - defense);
                // Убираем опцию.
                defense = 0;
                name = unit.Name();
            }
            else
            {
                defense -= strengthAttack;
            }
        }

        /// <summary>
        /// Метод вывода. 
        /// Строка идентификатора "M:Magic.ShieldDecorator.ToString".
        /// </summary>
        /// <returns>Вывод.</returns>     
        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {Health()} " +
                $"Сила: {Attack()} Стоимость: {Cost()} Броня {Defense()} Уклонение {Dodge()}");
        }

        /// <summary>
        /// Метод клонирования. 
        /// Строка идентификатора "M:Magic.ShieldDecorator.MakeClone".
        /// </summary>
        /// <returns>Клон.</returns>     
        public override IUnit MakeClone()
        {
            return unit.MakeClone();
        }
    }
}