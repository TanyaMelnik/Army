namespace Magic
{
    /// <summary>
    /// Класс ГуляйГорода.
    /// Строка идентификатора "T:Magic.Doctor".
    /// </summary> 
    class GulyayGorod
    {
        /// <summary>
        /// Поле щита.
        /// Строка идентификатора "F:Magic.GulyayGorod.type".
        /// </summary>
        public string type = "Щит гуляй город";

        // Здоровье.
        /// <summary>
        /// Поле здоровья.
        /// Строка идентификатора "F:Magic.GulyayGorod.strength".
        /// </summary>
        public int strength = 200;

        // Сила атаки.
        /// <summary>
        /// Поле силы атаки.
        /// Строка идентификатора "F:Magic.GulyayGorod.power".
        /// </summary>
        public int power = 0;

        // Стоимость.
        /// <summary>
        /// Поле стоимости.
        /// Строка идентификатора "F:Magic.GulyayGorod.cost".
        /// </summary>
        public int cost = 2;

        /// <summary>
        /// Метод получения урона.
        /// Строка идентификатора "М:Magic.GulyayGorod.GetDemage".
        /// </summary>
        public void GetDemage(int strengthAttack)
        {
            strength-=strengthAttack;
        }
    }

    /// <summary>
    /// Адаптер AdapterGulyayGorod реализует интерфейс IUnit и использует GulyayGorod.
    /// </summary>
    /// <param name="percentAttackAndDodge">Процент атаки и уклонения.</param>
    class AdapterGulyayGorod((int percentAttack, double percentDodge) 
        percentAttackAndDodge) : IUnit(percentAttackAndDodge)
    {
        /// <summary>
        /// Поле Гуляй Города.
        /// Строка идентификатора "F:Magic.GulyayGorod.gulyayGorod".
        /// </summary>
        private readonly GulyayGorod gulyayGorod = new();

        /// <summary>
        /// Метод названия.
        /// Строка идентификатора "M:Magic.GulyayGorod.Name".
        /// </summary>
        public override string Name() => gulyayGorod.type;

        /// <summary>
        /// Метод здоровья. 
        /// Строка идентификатора "M:Magic.GulyayGorod.Health".
        /// </summary>
        /// <returns>Значение здоровья.</returns> 
        public override int Health()
        {
            return gulyayGorod.strength;
        }

        /// <summary>
        /// Метод атаки. 
        /// Строка идентификатора "M:Magic.GulyayGorod.Attack".
        /// </summary>
        /// <returns>Значение силы.</returns> 
        public override int Attack()
        {
            return gulyayGorod.power;
        }

        /// <summary>
        /// Метод защиты. 
        /// Строка идентификатора "M:Magic.GulyayGorod.Defense".
        /// </summary>
        /// <returns>Значение защиты.</returns> 
        public override int Defense()
        {
            return 0;
        }

        /// <summary>
        /// Метод уклона. 
        /// Строка идентификатора "M:Magic.GulyayGorod.Dodge".
        /// </summary>
        /// <returns>Значение уклона.</returns> 
        public override double Dodge()
        {
            return 0;
        }

        /// <summary>
        /// Метод вывода.
        /// Строка идентификатора "M:Magic.GulyayGorod.ToString".
        /// </summary>
        /// <returns>Значения генерика.</returns>
        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {Health()} " +
                $"Сила: {attack} Стоимость: {cost} Броня {defense} Уклонение {dodge}");
        }

        /// <summary>
        /// Метод получения удара. 
        /// Строка идентификатора "M:Magic.GulyayGorod.GetHit".
        /// </summary>
        public override void GetHit(int strengthAttack)
        {
            gulyayGorod.GetDemage(strengthAttack);
        }

        /// <summary>
        /// Метод создания клона. 
        /// Строка идентификатора "M:Magic.GulyayGorod.MakeClone".
        /// </summary>
        /// <returns>Логирование атаки.</returns> 
        public override IUnit MakeClone()
        {
            var a = new AdapterGulyayGorod((0, 0));
            a.gulyayGorod.strength = gulyayGorod.strength;
            return new LogGetAttack(a, (0, 0));
        }

        /// <summary>
        /// Метод стоимости. 
        /// Строка идентификатора "M:Magic.GulyayGorod.Cost".
        /// </summary>
        /// <returns>Стоимость.</returns> 
        public override int Cost()
        {
            return gulyayGorod.cost;
        }
    }
}