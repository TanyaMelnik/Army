namespace Magic{

    public abstract class IUnit
    {
        /// <summary>
        /// Здоровье юнита.
        /// </summary>
        // Максимум 100.
        protected int health;
        public int Health { 
            get { return health; }
        }

        /// <summary>
        /// Сила юнита. Урон, который может нанести юнит
        /// </summary>
        // Максимум 50.
        protected int attack;
        public int Attack {
            get { return attack; }
        }

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
        protected double dodge;
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

        /// <summary>
        /// Конструктор, который берёт настройки из конфигурации.
        /// </summary>
        public IUnit(Settings settings, (int percentAttack, double percentDodge) percentAttackAndDodge)
        {
            health = settings.Health;
            attack = percentAttackAndDodge.percentAttack;
            dodge = percentAttackAndDodge.percentDodge;
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
        /// Метод атаки ближнего боя. Текущий бьёт второго.
        /// </summary>
/*        public void DoAttack(IUnit two)
        {
            if (two.defense >= attack) two.defense -= attack;
            else if (two.defense < attack && two.defense > 0)
            {
                int x = attack - two.defense;
                two.defense = 0;
                two.health -= x;
            }
            else two.health -= attack;
        }*/

        /*        public void AttackBo(IUnit two)
                {
                    if (two.defense >= attack) two.defense -= attack;
                    else if (two.defense < attack && two.defense > 0)
                    {
                        int x = attack - two.defense;
                        two.defense = 0;
                        two.health -= x;
                    }
                    else two.health -= attack;
                }*/

        public void GetHit(int strengthAttack)
        {
            if (defense >= strengthAttack) defense -= strengthAttack;
            else if (defense < strengthAttack && defense > 0)
            {
                int x = strengthAttack - defense;
                defense = 0;
                health -= x;
            }
            else health -= attack;
        }

    }
}