namespace Magic
{
    /// <summary>
    ///  Класс юнита.
    ///  Строка идентификатора "T:Magic.IUnit".
    /// </summary> 
    public abstract class IUnit((int percentAttack, double 
        percentDodge) percentAttackAndDodge)
    {
        /// <summary>
        /// Поле, содержащее тип юнита.
        /// Строка идентификатора "F:Magic.IUnit.name".
        /// </summary>
        protected string ?name;

        /// <summary>
        /// Метод имени юнита.
        /// Строка идентификатора "M:Magic.IUnit.Name)".
        /// </summary>
        public abstract string Name();

        /// <summary>
        /// Поле, содержащее здоровье юнита.
        /// Строка идентификатора "F:Magic.IUnit.health".
        /// </summary>
        protected int health = Settings.GetInstance(0,0).Health;

        /// <summary>
        /// Метод здоровья юнита.
        /// Строка идентификатора "M:Magic.IUnit.Health)".
        /// </summary>
        public abstract int Health();

         /// <summary>
        /// Поле, содержащее силу урона.
        /// Строка идентификатора "F:Magic.IUnit.percentAttack".
        /// </summary>
        protected int attack = percentAttackAndDodge.percentAttack;

        /// <summary>
        /// Метод аттаки юнита.
        /// Строка идентификатора "M:Magic.IUnit.Attack)".
        /// </summary>
        public abstract int Attack();

        /// <summary>
        /// Поле, содержащее стоимость юнита.
        /// Строка идентификатора "F:Magic.IUnit.cost".
        /// </summary>
        protected int cost;

        /// <summary>
        /// Метод стоимости юнита.
        /// Строка идентификатора "M:Magic.IUnit.Cost".
        /// </summary>
        public abstract int Cost();

        /// <summary>
        /// Поле, содержащее уклонение юнита.
        /// Строка идентификатора "F:Magic.IUnit.percentDodge".
        /// </summary>
        protected double dodge = percentAttackAndDodge.percentDodge;

        /// <summary>
        /// Метод уклонения юнита.
        /// Строка идентификатора "M:Magic.IUnit.Dodge".
        /// </summary>
        public abstract double Dodge();

        /// <summary>
        /// Поле, содержащее защиту.
        /// Строка идентификатора "F:Magic.IUnit.defense".
        /// </summary>
        protected int defense;

        /// <summary>
        /// Метод защиты.
        /// Строка идентификатора "M:Magic.IUnit.Defense".
        /// </summary>
        public abstract int Defense();

        /// <summary>
        /// Метод представления юнита.
        /// </summary>
        /// <returns>Строку, представляющий юнит.</returns>
        public override abstract string ToString();

        /// <summary>
        /// Метод получения удара.
        /// </summary>
        /// <param name="strengthAttack">Получаемый урон.</param>
        public abstract void GetHit(int strengthAttack);

        /// <summary>
        /// Метод клонирования юнита.
        /// Строка идентификатора "M:Magic.IUnit.MakeClone".
        /// </summary>
        public abstract IUnit MakeClone();

    }
}