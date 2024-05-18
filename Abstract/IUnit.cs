namespace Magic
{
    public abstract class IUnit((int percentAttack, double percentDodge) percentAttackAndDodge)
    {
        protected string name;
        public abstract string Name();
        /// <summary>
        /// Здоровье юнита.
        /// </summary>
        protected int health = Settings.GetInstance(0,0).Health;
        public abstract int Health();
        /// <summary>
        /// Сила/урон юнита.
        /// </summary>
        protected int attack = percentAttackAndDodge.percentAttack;
        public abstract int Attack();
        /// <summary>
        /// Стоимость юнита.
        /// </summary>
        protected int cost;
        public abstract int Cost();
        /// <summary>
        /// Уклонение юнита.
        /// </summary>
        protected double dodge = percentAttackAndDodge.percentDodge;
        public abstract double Dodge();
        /// <summary>
        /// Доп защита.
        /// </summary>
        protected int defense;
        public abstract int Defense();
        public int GetCost()
        {
            return cost;
        }
        /// <summary>
        /// Метод представления юнита.
        /// </summary>
        /// <returns>Строку, представляющий юнит.</returns>
        public override abstract string ToString();

        public abstract void GetHit(int strengthAttack);
        public abstract IUnit MakeClone();

    }
}