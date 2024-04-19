namespace Magic{

    abstract class IUnit
    {
        /// <summary>
        /// Здоровье юнита.
        /// </summary>
        public int health;

        /// <summary>
        /// Сила юнита. Урон, который может нанести юнит
        /// </summary>
        public int attack;

        /// <summary>
        /// Стоимость юнита.
        /// </summary>
        public int cost;

        /// <summary>
        /// Уклонение юнита.
        /// </summary>
        public double dodge;

        /// <summary>
        /// Доп защита.
        /// </summary>
        public int defense;

        /// <summary>
        /// Конструктор, который берёт настройки из конфигурации.
        /// </summary>
        public IUnit()
        {

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