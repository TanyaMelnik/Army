namespace Magic
{
    /// <summary>
    ///  Класс коня.
    ///  Строка идентификатора "T:Magic.HelmDecorator".
    /// </summary>
    public class HorseDecorator : OptionDecorator
    {
        /// <summary>
        /// Метод, содержащий декоратор - конь. 
        /// Строка идентификатора "M:Magic.HorseDecorator.HorseDecorator".
        /// </summary>
        /// <param name="unit">Юнит, получивший свойства.</param>
        /// <param name="persentAttackAndDodge">Процент атаки и уклонения.</param>
        public HorseDecorator(IUnit unit, (int, double) persentAttackAndDodge) : 
            base(unit, persentAttackAndDodge)
        {
            // Характеристики опции.
            attack = 25;
            defense = 20;
            name = unit.Name() + " с конём";
        }

        /// <summary>
        /// Метод имени. 
        /// Строка идентификатора "M:Magic.HorseDecorator.Name".
        /// </summary>
        public override string Name() => name ?? "";

        /// <summary>
        /// Метод атаки. 
        /// Строка идентификатора "M:Magic.HorseDecorator.Attack".
        /// </summary>
        public override int Attack() => unit.Attack() + attack;

        /// <summary>
        /// Метод защиты. 
        /// Строка идентификатора "M:Magic.HorseDecorator.Defense".
        /// </summary>
        public override int Defense() => unit.Defense() + defense;

        /// <summary>
        /// Метод урона. 
        /// Строка идентификатора "M:Magic.HorseDecorator.Dodge".
        /// </summary>
        public override double Dodge() => unit.Dodge();

        /// <summary>
        /// Метод стоимости. 
        /// Строка идентификатора "M:Magic.HorseDecorator.Cost".
        /// </summary>
        public override int Cost() => unit.Cost();

        /// <summary>
        /// Метод получения удара. 
        /// Строка идентификатора "M:Magic.HorseDecorator.GetHit(Magic.int)".
        /// </summary>
        public override void GetHit(int strengthAttack)
        {
            // Если опция сбивается. 
            if (strengthAttack - defense >= 0)
            {
                unit.GetHit(strengthAttack - defense);
                // Убираем опцию.
                defense = 0;
                attack = 0;
                name = unit.Name();
            }
            else
            {
                defense -= strengthAttack;
            }
        }

        /// <summary>
        /// Метод здоровья. 
        /// Строка идентификатора "M:Magic.HorseDecorator.Health".
        /// </summary>
        public override int Health() => unit.Health();

        /// <summary>
        /// Метод вывода. 
        /// Строка идентификатора "M:Magic.HorseDecorator.ToString".
        /// </summary>
        /// <returns>Вывод.</returns>     
        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {Health()} " +
                $"Сила: {Attack()} Стоимость: {Cost()} Броня {Defense()} Уклонение {Dodge()}");
        }

        /// <summary>
        /// Метод клонирования. 
        /// Строка идентификатора "M:Magic.HorseDecorator.MakeClone".
        /// </summary>
        /// <returns>Клон.</returns>     
        public override IUnit MakeClone()
        {
            return unit.MakeClone();
        }
    }
}
