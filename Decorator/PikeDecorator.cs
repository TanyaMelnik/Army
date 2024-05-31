namespace Magic
{
    /// <summary>
    ///  Класс пика.
    ///  Строка идентификатора "T:Magic.PikeDecorator".
    /// </summary>
    public class PikeDecorator : OptionDecorator
    {
        /// <summary>
        /// Метод, содержащий декоратор-пика.
        /// Строка идентификатора "M:Magic.PikeDecorator.PikeDecorator".
        /// </summary>
        /// <param name="unit">Юнит, получивший свойства.</param>
        /// <param name="persentAttackAndDodge">Процент атаки и уклонения.</param>
        public PikeDecorator(IUnit unit, (int, double) persentAttackAndDodge) : 
            base(unit, persentAttackAndDodge)
        {
            // Характеристики опции.
            attack = 15;
            defense = 10;
            name = unit.Name() + " с пикой";
        }

        /// <summary>
        /// Метод имени. 
        /// Строка идентификатора "M:Magic.PikeDecorator.Name".
        /// </summary>
        public override string Name() => name ?? "";

        /// <summary>
        /// Метод атаки. 
        /// Строка идентификатора "M:Magic.PikeDecorator.Attack".
        /// </summary>
        public override int Attack() => unit.Attack() + attack;

        /// <summary>
        /// Метод защиты. 
        /// Строка идентификатора "M:Magic.PikeDecorator.Defense".
        /// </summary>
        public override int Defense() => unit.Defense() + defense;

        /// <summary>
        /// Метод урона. 
        /// Строка идентификатора "M:Magic.PikeDecorator.Dodge".
        /// </summary>
        public override double Dodge() => unit.Dodge();

        /// <summary>
        /// Метод здоровья. 
        /// Строка идентификатора "M:Magic.PikeDecorator.Health".
        /// </summary>
        public override int Health() => unit.Health();

        /// <summary>
        /// Метод получения удара. 
        /// Строка идентификатора "M:Magic.PikeDecorator.GetHit(Magic.int)".
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
        /// Метод стоимости. 
        /// Строка идентификатора "M:Magic.PikeDecorator.Cost".
        /// </summary>
        public override int Cost() => unit.Cost();

        /// <summary>
        /// Метод вывода. 
        /// Строка идентификатора "M:Magic.PikeDecorator.ToString".
        /// </summary>
        /// <returns>Вывод.</returns>     
        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {Health()} Сила: {Attack()} " +
                $"Стоимость: {Cost()} Броня {Defense()} Уклонение {unit.Dodge}");
        }

        /// <summary>
        /// Метод клонирования. 
        /// Строка идентификатора "M:Magic.PikeDecorator.MakeClone".
        /// </summary>
        /// <returns>Клон.</returns>     
        public override IUnit MakeClone()
        {
            return unit.MakeClone();
        }
    }
}