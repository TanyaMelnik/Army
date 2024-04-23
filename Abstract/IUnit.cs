namespace Magic{

    abstract class IUnit
    {
        /// <summary>
        /// Здоровье юнита.
        /// </summary>
        protected int health;

        /// <summary>
        /// Сила юнита. Урон, который может нанести юнит
        /// </summary>
        protected int attack;

        /// <summary>
        /// Стоимость юнита.
        /// </summary>
        protected int cost;

        /// <summary>
        /// Уклонение юнита.
        /// </summary>
        protected double dodge;

        /// <summary>
        /// Доп защита.
        /// </summary>
        protected int defense;

        /// <summary>
        /// Конструктор, который берёт настройки из конфигурации.
        /// </summary>
        public IUnit()
        {

        }
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