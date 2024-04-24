namespace Magic{

    public abstract class IUnit
    {
        /// <summary>
        /// Здоровье юнита.
        /// </summary>
        // Максимум 100.
        protected int health;

        /// <summary>
        /// Сила юнита. Урон, который может нанести юнит
        /// </summary>
        // Максимум 50.
        protected int attack;

        /// <summary>
        /// Стоимость юнита.
        /// </summary>
        protected int cost;

        /// <summary>
        /// Уклонение юнита.
        /// </summary>
        // Максимум 1
        protected double dodge;

        /// <summary>
        /// Доп защита.
        /// </summary>
        // Максимум 100
        protected int defense;

        public int GetCost()
        {
            return cost;
        }
        /// <summary>
        /// Метод представления юнита.
        /// </summary>
        /// <returns></returns>
        public abstract string ToString();

        /// <summary>
        /// Метод атаки.
        /// </summary>
        /// <returns>
        /// Силу атаки от этого юнита.
        /// </returns>
        public abstract void Attack(IUnit two);
    }
}