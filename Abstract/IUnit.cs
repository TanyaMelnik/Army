namespace Magic{

    /// <summary>
    /// Конструктор, который берёт настройки из конфигурации.
    /// </summary>
    public abstract class IUnit((int percentAttack, double percentDodge) percentAttackAndDodge)
    {
        /// <summary>
        /// Здоровье юнита.
        /// </summary>
        // Максимум 100.
        protected int health = Settings.GetInstance(0,0).Health;
        public abstract int Health();

        /// <summary>
        /// Сила юнита. Урон, который может нанести юнит
        /// </summary>
        // Максимум 50.
        protected int attack = percentAttackAndDodge.percentAttack;
        public abstract int Attack();

        /// <summary>
        /// Стоимость юнита.
        /// </summary>
        protected int cost;
        public int Cost
        {
            get { return cost; }
        }
        /// <summary>
        /// Уклонение юнита.
        /// </summary>
        // Максимум 1
        protected double dodge = percentAttackAndDodge.percentDodge;
        public double Dodge
        {
            get { return dodge; }
        }
        /// <summary>
        /// Доп защита.
        /// </summary>
        // Максимум 100
        protected int defense;
        public int Defense
        {
            get { return defense; }
        }

        public int GetCost()
        {
            return cost;
        }
        /// <summary>
        /// Метод представления юнита.
        /// </summary>
        /// <returns></returns>
        public override abstract string ToString();

        public abstract void GetHit(int strengthAttack);
        

    }
}