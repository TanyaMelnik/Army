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
        public int Health { 
            get { return health; }
        }

        /// <summary>
        /// Сила юнита. Урон, который может нанести юнит
        /// </summary>
        // Максимум 50.
        protected int attack = percentAttackAndDodge.percentAttack;
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

        public void GetHit(int strengthAttack)
        {
            Random random = new Random();
            double randomNumber = random.NextDouble();
            //Если уклонение не произошло => unit получает урон 
            if (dodge < randomNumber)
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
}