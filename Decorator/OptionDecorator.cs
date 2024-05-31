namespace Magic
{
    /// <summary>
    /// Абстрактный класс декоратора.
    ///  Строка идентификатора "T:Magic.OptionDecorator".
    /// </summary>
    /// <param name="unit">Юнит, получивший свойства.</param>
    /// <param name="persentAttackAndDodge">Процент атаки и уклонения.</param>
    public abstract class OptionDecorator(IUnit unit, (int, double) 
        persentAttackAndDodge) : IUnit(persentAttackAndDodge)
    {
        protected IUnit unit = unit;
    }
}
